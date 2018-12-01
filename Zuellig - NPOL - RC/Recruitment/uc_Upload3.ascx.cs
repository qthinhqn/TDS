using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NPOL.App_Code.Business;
using NPOL.App_Code.Entities;
using System.Configuration;

namespace NPOL.Recruitment
{
    public partial class uc_Upload3 : System.Web.UI.UserControl
    {
        public void ReloadControl()
        {
            // Code here to refresh controls on page
            // Page_Load(null, null);
            //LoadAttachment();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    generateID();
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void generateID()
        {
            //try
            //{
            //    if (SubmissionID3 != null)
            //    { }
            //    else{
                    SubmissionID3 = UploadControlHelper3.GenerateUploadedFilesStorageKey();
                    UploadControlHelper3.AddUploadedFilesStorage(SubmissionID3);
            //    }
            //}catch(Exception ex)
            //{
            //    SubmissionID3 = UploadControlHelper2.GenerateUploadedFilesStorageKey();
            //    UploadControlHelper3.AddUploadedFilesStorage(SubmissionID3);
            //}
        }

        #region upload

        protected string SubmissionID3
        {
            get
            {
                return HiddenField3.Get("SubmissionID3").ToString();
            }
            set
            {
                HiddenField3.Set("SubmissionID3", value);
            }
        }
        UploadedFilesStorage3 UploadedFilesStorage
        {
            get { return UploadControlHelper3.GetUploadedFilesStorageByKey(SubmissionID3); }
        }
        protected void DocumentsUploadControl_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            bool isSubmissionExpired = false;
            if (UploadedFilesStorage == null)
            {
                isSubmissionExpired = true;
                UploadControlHelper3.AddUploadedFilesStorage(SubmissionID3);
            }
            else
            {
                UploadControlHelper3.RemoveUploadedFilesStorage(SubmissionID3);
                isSubmissionExpired = true;
                UploadControlHelper3.AddUploadedFilesStorage(SubmissionID3);
            }
            UploadedFileInfo3 tempFileInfo = UploadControlHelper3.AddUploadedFileInfo(SubmissionID3, e.UploadedFile.FileName);


            e.UploadedFile.SaveAs(tempFileInfo.FilePath);

            if (e.IsValid)
                e.CallbackData = tempFileInfo.UniqueFileName + "|" + isSubmissionExpired;
        }
        void ValidateInputData()
        {
            //bool isInvalid = string.IsNullOrEmpty(DescriptionTextBox.Text) || UploadedFilesTokenBox.Tokens.Count == 0;
            bool isInvalid = UploadedFilesTokenBox3.Tokens.Count == 0;
            if (isInvalid)
                throw new Exception("Invalid input data");
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

        protected void ProcessSubmit(List<UploadedFileInfo3> fileInfos, string requestID, string attachType)
        {
            //DescriptionLabel.Value = Server.HtmlEncode("");

            foreach (UploadedFileInfo3 fileInfo in fileInfos)
            {
                // process uploaded files here
                //byte[] fileContent = File.ReadAllBytes(fileInfo.FilePath);
                string path = fileInfo.FilePath;
                string pathtemp = ConfigurationManager.AppSettings["AttachPath_RC"] + requestID;
                string path2 = HttpRuntime.AppDomainAppPath + pathtemp;
                try
                {
                    if (!Directory.Exists(path2))
                        Directory.CreateDirectory(path2);

                    path2 = path2 + @"\" + fileInfo.UniqueFileName;
                    // Ensure that the target does not exist.
                    if (File.Exists(path2))
                        File.Delete(path2);

                    // Move the file.
                    File.Move(path, path2);

                    // Save attach table
                    tbl_Attachment_RC obj = new tbl_Attachment_RC();
                    obj.AttachmentName = fileInfo.OriginalFileName;
                    obj.AttachmentPath = pathtemp;
                    obj.FileSize = fileInfo.FileSize;
                    obj.FileType = fileInfo.FileType;
                    obj.RequestID = requestID;
                    obj.AttachType = attachType;
                    Attachment_RCService.CreateNews(obj);
                    if (obj.ID == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('Lưu file đính kèm bị lỗi !')", true);

                    }
                    else
                    {
                        //LoadAttachment();
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
        #endregion


        public bool Validate()
        {
            return (UploadedFilesTokenBox3.Tokens.Count > 0);
        }

        public void Submit_Attach(string requestID, string type)
        {

            List<UploadedFileInfo3> resultFileInfos = new List<UploadedFileInfo3>();
            //string description = DescriptionTextBox.Text;
            bool allFilesExist = true;

            if (UploadedFilesStorage == null)
                UploadedFilesTokenBox3.Tokens = new TokenCollection();

            foreach (string fileName in UploadedFilesTokenBox3.Tokens)
            {
                UploadedFileInfo3 demoFileInfo = UploadControlHelper3.GetDemoFileInfo(SubmissionID3, fileName);
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
                ProcessSubmit(resultFileInfos, requestID, type);
                // remove files in temp
                UploadControlHelper3.RemoveUploadedFilesStorage(SubmissionID3);
                // Clear content in editor
                //ASPxEdit.ClearEditorsInContainer(FormLayout, true);
            }
            else
            {
                UploadedFilesTokenBox3.ErrorText = "Submit failed because files have been removed from the server due to the 5 minute timeout.";
                UploadedFilesTokenBox3.IsValid = false;
            }
        }

        public void ClearTokenBox()
        {
            UploadedFilesTokenBox3.Tokens.Clear();
            UploadControlHelper1.RemoveUploadedFilesStorage(SubmissionID3);
        }
    }

    public class UploadedFilesStorage3
    {
        public string Path { get; set; }
        public string Key { get; set; }
        public DateTime LastUsageTime { get; set; }

        public IList<UploadedFileInfo3> Files { get; set; }
    }

    public class UploadedFileInfo3
    {
        public string UniqueFileName { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
    }


    public static class UploadControlHelper3
    {
        const int DisposeTimeout = 5;
        const string FolderKey = "Recruitment";
        const string TempDirectory = "~/Recruitment/Temp/";
        static readonly object storageListLocker = new object();

        static HttpContext Context { get { return HttpContext.Current; } }
        static string RootDirectory { get { return Context.Request.MapPath(TempDirectory); } }

        static IList<UploadedFilesStorage3> uploadedFilesStorageList;
        static IList<UploadedFilesStorage3> UploadedFilesStorageList
        {
            get
            {
                return uploadedFilesStorageList;
            }
        }

        static UploadControlHelper3()
        {
            uploadedFilesStorageList = new List<UploadedFilesStorage3>();
        }

        static string CreateTempDirectoryCore()
        {
            string uploadDirectory = Path.Combine(RootDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(uploadDirectory);

            return uploadDirectory;
        }
        public static UploadedFilesStorage3 GetUploadedFilesStorageByKey(string key)
        {
            lock (storageListLocker)
            {
                return GetUploadedFilesStorageByKeyUnsafe(key);
            }
        }
        static UploadedFilesStorage3 GetUploadedFilesStorageByKeyUnsafe(string key)
        {
            UploadedFilesStorage3 storage = UploadedFilesStorageList.Where(i => i.Key == key).SingleOrDefault();
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
                UploadedFilesStorage3 storage = new UploadedFilesStorage3
                {
                    Key = key,
                    Path = CreateTempDirectoryCore(),
                    LastUsageTime = DateTime.Now,
                    Files = new List<UploadedFileInfo3>()
                };
                UploadedFilesStorageList.Add(storage);
            }
        }
        public static void RemoveUploadedFilesStorage(string key)
        {
            lock (storageListLocker)
            {
                UploadedFilesStorage3 storage = GetUploadedFilesStorageByKeyUnsafe(key);
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
                    UploadedFilesStorage3 storage = UploadedFilesStorageList.Where(i => i.Path == directoryPath).SingleOrDefault();
                    if (storage == null || (DateTime.Now - storage.LastUsageTime).TotalMinutes > DisposeTimeout)
                    {
                        Directory.Delete(directoryPath, true);
                        if (storage != null)
                            UploadedFilesStorageList.Remove(storage);
                    }
                }
            }
        }
        public static UploadedFileInfo3 AddUploadedFileInfo(string key, string originalFileName)
        {
            UploadedFilesStorage3 currentStorage = GetUploadedFilesStorageByKey(key);
            UploadedFileInfo3 fileInfo = new UploadedFileInfo3
            {
                FilePath = Path.Combine(currentStorage.Path, Path.GetRandomFileName()),
                OriginalFileName = originalFileName,
                UniqueFileName = GetUniqueFileName(currentStorage, originalFileName)
            };
            currentStorage.Files.Add(fileInfo);

            return fileInfo;
        }
        public static UploadedFileInfo3 GetDemoFileInfo(string key, string fileName)
        {
            UploadedFilesStorage3 currentStorage = GetUploadedFilesStorageByKey(key);
            return currentStorage.Files.Where(i => i.UniqueFileName == fileName).SingleOrDefault();
        }
        public static string GetUniqueFileName(UploadedFilesStorage3 currentStorage, string fileName)
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