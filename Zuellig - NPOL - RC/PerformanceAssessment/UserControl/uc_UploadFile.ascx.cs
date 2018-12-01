using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PAOL.App_Code.Business;
using PAOL.App_Code.Entities;
using System.Configuration;

namespace PAOL.UserControl
{
    public partial class uc_UploadFile : System.Web.UI.UserControl, IControlBase
    {
        public void ReloadControl()
        {
            // Code here to refresh controls on page
            Page_Load(null, null);
            LoadAttachment();
        }
        protected string SubmissionID
        {
            get
            {
                return HiddenField.Get("SubmissionID").ToString();
            }
            set
            {
                HiddenField.Set("SubmissionID", value);
            }
        }
        UploadedFilesStorage UploadedFilesStorage
        {
            get { return UploadControlHelper.GetUploadedFilesStorageByKey(SubmissionID); }
        }

        protected void ProcessSubmit(List<UploadedFileInfo> fileInfos)
        {
            //DescriptionLabel.Value = Server.HtmlEncode("");

            foreach (UploadedFileInfo fileInfo in fileInfos)
            {
                // process uploaded files here
                //byte[] fileContent = File.ReadAllBytes(fileInfo.FilePath);
                string path = fileInfo.FilePath;
                string pathtemp = ConfigurationManager.AppSettings["AttachPath"] + fileInfo.UniqueFileName;
                string path2 = HttpRuntime.AppDomainAppPath + pathtemp;
                try
                {
                    if (!File.Exists(path))
                    {
                        // This statement ensures that the file is created,
                        // but the handle is not kept.
                        using (FileStream fs = File.Create(path)) { }
                    }

                    // Ensure that the target does not exist.
                    if (File.Exists(path2))
                        File.Delete(path2);

                    // Move the file.
                    File.Move(path, path2);

                    // Save attach table
                    tbl_Attachment obj = new tbl_Attachment();
                    obj.AttachmentName = fileInfo.OriginalFileName;
                    obj.AttachmentPath = pathtemp;
                    obj.FileSize = fileInfo.FileSize;
                    obj.FileType = fileInfo.FileType;
                    obj.NewsID = int.Parse(Session["NewsID"].ToString());
                    AttachmentService.CreateNews(obj);
                    if (obj.ID == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Lưu file đính kèm bị lỗi !')", true);

                    }
                    else
                    {
                        LoadAttachment();
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('File đính kèm đã được lưu lại !')", true);
                    }

                }
                catch (Exception e)
                {
                }
            }

            //SubmittedFilesListBox.DataSource = fileInfos;
            //SubmittedFilesListBox.DataBind();

            //FormLayout.FindItemOrGroupByName("ResultGroup").Visible = true;
        }

        protected void Page_PreLoad(object sender, EventArgs e)
        {
            // Remove old files
            UploadControlHelper.RemoveOldStorages();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
			if (!IsPostBack)
			{
				SubmissionID = UploadControlHelper.GenerateUploadedFilesStorageKey();
				UploadControlHelper.AddUploadedFilesStorage(SubmissionID);
					
				// Load list attachment
				LoadAttachment();
			}
        }

        private void LoadAttachment()
        {
            if (Session["NewsID"] != null)
            {
                int newsid = int.Parse(Session["NewsID"].ToString());
                gv_Attach.DataSource = PAOL.App_Code.Business.AttachmentService.GetTableByNewsid(newsid);
                gv_Attach.DataBind();
            }
        }

        protected void DocumentsUploadControl_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            bool isSubmissionExpired = false;
            if (UploadedFilesStorage == null)
            {
                isSubmissionExpired = true;
                UploadControlHelper.AddUploadedFilesStorage(SubmissionID);
            }
            UploadedFileInfo tempFileInfo = UploadControlHelper.AddUploadedFileInfo(SubmissionID, e.UploadedFile.FileName);

            e.UploadedFile.SaveAs(tempFileInfo.FilePath);

            if (e.IsValid)
                e.CallbackData = tempFileInfo.UniqueFileName + "|" + isSubmissionExpired;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            ValidateInputData();

            List<UploadedFileInfo> resultFileInfos = new List<UploadedFileInfo>();
            //string description = DescriptionTextBox.Text;
            bool allFilesExist = true;

            if (UploadedFilesStorage == null)
                UploadedFilesTokenBox.Tokens = new TokenCollection();

            foreach (string fileName in UploadedFilesTokenBox.Tokens)
            {
                UploadedFileInfo demoFileInfo = UploadControlHelper.GetDemoFileInfo(SubmissionID, fileName);
                FileInfo fileInfo = new FileInfo(demoFileInfo.FilePath);

                if (fileInfo.Exists)
                {
                    demoFileInfo.FileSize = FormatSize(fileInfo.Length);
                    resultFileInfos.Add(demoFileInfo);
                }
                else
                    allFilesExist = false;
            }

            if (allFilesExist && resultFileInfos.Count > 0)
            {
                // move files from temp to attach
                //ProcessSubmit(description, resultFileInfos);
                ProcessSubmit(resultFileInfos);
                // remove files in temp
                UploadControlHelper.RemoveUploadedFilesStorage(SubmissionID);
                // Clear content in editor
                ASPxEdit.ClearEditorsInContainer(FormLayout, true);
            }
            else
            {
                UploadedFilesTokenBox.ErrorText = "Submit failed because files have been removed from the server due to the 5 minute timeout.";
                UploadedFilesTokenBox.IsValid = false;
            }
        }

        public string FormatSize(object value)
        {
            double amount = Convert.ToDouble(value);
            string unit = "KB";
            if (amount != 0)
            {
                if (amount <= 1024)
                    amount = 1;
                else
                    amount /= 1024;

                if (amount > 1024)
                {
                    amount /= 1024;
                    unit = "MB";
                }
                if (amount > 1024)
                {
                    amount /= 1024;
                    unit = "GB";
                }
            }
            return String.Format("{0:#,0} {1}", Math.Round(amount, MidpointRounding.AwayFromZero), unit);
        }
        void ValidateInputData()
        {
            //bool isInvalid = string.IsNullOrEmpty(DescriptionTextBox.Text) || UploadedFilesTokenBox.Tokens.Count == 0;
            bool isInvalid = UploadedFilesTokenBox.Tokens.Count == 0;
            if (isInvalid)
                throw new Exception("Invalid input data");
        }

    }
    public class UploadedFilesStorage
    {
        public string Path { get; set; }
        public string Key { get; set; }
        public DateTime LastUsageTime { get; set; }

        public IList<UploadedFileInfo> Files { get; set; }
    }

    public class UploadedFileInfo
    {
        public string UniqueFileName { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
    }


    public static class UploadControlHelper
    {
        const int DisposeTimeout = 5;
        const string FolderKey = "NewsData";
        const string TempDirectory = "~/NewsData/Temp/";
        static readonly object storageListLocker = new object();

        static HttpContext Context { get { return HttpContext.Current; } }
        static string RootDirectory { get { return Context.Request.MapPath(TempDirectory); } }

        static IList<UploadedFilesStorage> uploadedFilesStorageList;
        static IList<UploadedFilesStorage> UploadedFilesStorageList
        {
            get
            {
                return uploadedFilesStorageList;
            }
        }

        static UploadControlHelper()
        {
            uploadedFilesStorageList = new List<UploadedFilesStorage>();
        }

        static string CreateTempDirectoryCore()
        {
            string uploadDirectory = Path.Combine(RootDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(uploadDirectory);

            return uploadDirectory;
        }
        public static UploadedFilesStorage GetUploadedFilesStorageByKey(string key)
        {
            lock (storageListLocker)
            {
                return GetUploadedFilesStorageByKeyUnsafe(key);
            }
        }
        static UploadedFilesStorage GetUploadedFilesStorageByKeyUnsafe(string key)
        {
            UploadedFilesStorage storage = UploadedFilesStorageList.Where(i => i.Key == key).SingleOrDefault();
            if (storage != null)
                storage.LastUsageTime = DateTime.Now;
            return storage;
        }
        public static string GenerateUploadedFilesStorageKey()
        {
            return Guid.NewGuid().ToString("N");
        }
        public static void AddUploadedFilesStorage(string key)
        {
            lock (storageListLocker)
            {
                UploadedFilesStorage storage = new UploadedFilesStorage
                {
                    Key = key,
                    Path = CreateTempDirectoryCore(),
                    LastUsageTime = DateTime.Now,
                    Files = new List<UploadedFileInfo>()
                };
                UploadedFilesStorageList.Add(storage);
            }
        }
        public static void RemoveUploadedFilesStorage(string key)
        {
            lock (storageListLocker)
            {
                UploadedFilesStorage storage = GetUploadedFilesStorageByKeyUnsafe(key);
                if (storage != null)
                {
                    Directory.Delete(storage.Path, true);
                    UploadedFilesStorageList.Remove(storage);
                }
            }
        }
        public static void RemoveOldStorages()
        {
            if (!Directory.Exists(RootDirectory))
                Directory.CreateDirectory(RootDirectory);

            lock (storageListLocker)
            {
                string[] existingDirectories = Directory.GetDirectories(RootDirectory);
                foreach (string directoryPath in existingDirectories)
                {
                    UploadedFilesStorage storage = UploadedFilesStorageList.Where(i => i.Path == directoryPath).SingleOrDefault();
                    if (storage == null || (DateTime.Now - storage.LastUsageTime).TotalMinutes > DisposeTimeout)
                    {
                        Directory.Delete(directoryPath, true);
                        if (storage != null)
                            UploadedFilesStorageList.Remove(storage);
                    }
                }
            }
        }
        public static UploadedFileInfo AddUploadedFileInfo(string key, string originalFileName)
        {
            UploadedFilesStorage currentStorage = GetUploadedFilesStorageByKey(key);
            UploadedFileInfo fileInfo = new UploadedFileInfo
            {
                FilePath = Path.Combine(currentStorage.Path, Path.GetRandomFileName()),
                OriginalFileName = originalFileName,
                UniqueFileName = GetUniqueFileName(currentStorage, originalFileName)
            };
            currentStorage.Files.Add(fileInfo);

            return fileInfo;
        }
        public static UploadedFileInfo GetDemoFileInfo(string key, string fileName)
        {
            UploadedFilesStorage currentStorage = GetUploadedFilesStorageByKey(key);
            return currentStorage.Files.Where(i => i.UniqueFileName == fileName).SingleOrDefault();
        }
        public static string GetUniqueFileName(UploadedFilesStorage currentStorage, string fileName)
        {
            string baseName = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            int index = 1;

            while (currentStorage.Files.Any(i => i.UniqueFileName == fileName))
                fileName = string.Format("{0} ({1}){2}", baseName, index++, ext);

            return fileName;
        }
    }
}