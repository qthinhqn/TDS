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
    public partial class uc_Upload1 : System.Web.UI.UserControl
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
            //    if (SubmissionID1 != null)
            //    { }
            //    else{
                    SubmissionID1 = UploadControlHelper1.GenerateUploadedFilesStorageKey();
                    UploadControlHelper1.AddUploadedFilesStorage(SubmissionID1);
            //    }
            //}catch(Exception ex)
            //{
            //    SubmissionID1 = UploadControlHelper2.GenerateUploadedFilesStorageKey();
            //    UploadControlHelper2.AddUploadedFilesStorage(SubmissionID1);
            //}
        }

        #region upload

        protected string SubmissionID1
        {
            get
            {
                return HiddenField1.Get("SubmissionID1").ToString();
            }
            set
            {
                HiddenField1.Set("SubmissionID1", value);
            }
        }
        UploadedFilesStorage1 UploadedFilesStorage
        {
            get { return UploadControlHelper1.GetUploadedFilesStorageByKey(SubmissionID1); }
        }
        protected void DocumentsUploadControl_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            bool isSubmissionExpired = false;
            if (UploadedFilesStorage == null)
            {
                isSubmissionExpired = true;
                UploadControlHelper1.AddUploadedFilesStorage(SubmissionID1);
            }
            else
            {
                UploadControlHelper1.RemoveUploadedFilesStorage(SubmissionID1);
                isSubmissionExpired = true;
                UploadControlHelper1.AddUploadedFilesStorage(SubmissionID1);
            }
            UploadedFileInfo1 tempFileInfo = UploadControlHelper1.AddUploadedFileInfo(SubmissionID1, e.UploadedFile.FileName);


            e.UploadedFile.SaveAs(tempFileInfo.FilePath);

            if (e.IsValid)
                e.CallbackData = tempFileInfo.UniqueFileName + "|" + isSubmissionExpired;
        }
        void ValidateInputData()
        {
            //bool isInvalid = string.IsNullOrEmpty(DescriptionTextBox.Text) || UploadedFilesTokenBox.Tokens.Count == 0;
            bool isInvalid = UploadedFilesTokenBox1.Tokens.Count == 0;
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

        protected void ProcessSubmit(List<UploadedFileInfo1> fileInfos, string requestID, string attachType)
        {
            //DescriptionLabel.Value = Server.HtmlEncode("");

            foreach (UploadedFileInfo1 fileInfo in fileInfos)
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
            return (UploadedFilesTokenBox1.Tokens.Count > 0);
        }

        public void Submit_Attach(string requestID, string type)
        {

            List<UploadedFileInfo1> resultFileInfos = new List<UploadedFileInfo1>();
            //string description = DescriptionTextBox.Text;
            bool allFilesExist = true;

            if (UploadedFilesStorage == null)
                UploadedFilesTokenBox1.Tokens = new TokenCollection();

            foreach (string fileName in UploadedFilesTokenBox1.Tokens)
            {
                UploadedFileInfo1 demoFileInfo = UploadControlHelper1.GetDemoFileInfo(SubmissionID1, fileName);
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
                UploadControlHelper1.RemoveUploadedFilesStorage(SubmissionID1);
                // Clear content in editor
                //ASPxEdit.ClearEditorsInContainer(FormLayout, true);
            }
            else
            {
                UploadedFilesTokenBox1.ErrorText = "Submit failed because files have been removed from the server due to the 5 minute timeout.";
                UploadedFilesTokenBox1.IsValid = false;
            }
        }

        public void ClearTokenBox()
        {
            UploadedFilesTokenBox1.Tokens.Clear();
            UploadControlHelper1.RemoveUploadedFilesStorage(SubmissionID1);
        }
    }

    public class UploadedFilesStorage1
    {
        public string Path { get; set; }
        public string Key { get; set; }
        public DateTime LastUsageTime { get; set; }

        public IList<UploadedFileInfo1> Files { get; set; }
    }

    public class UploadedFileInfo1
    {
        public string UniqueFileName { get; set; }
        public string OriginalFileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
    }


    public static class UploadControlHelper1
    {
        const int DisposeTimeout = 5;
        const string FolderKey = "Recruitment";
        const string TempDirectory = "~/Recruitment/Temp/";
        static readonly object storageListLocker = new object();

        static HttpContext Context { get { return HttpContext.Current; } }
        static string RootDirectory { get { return Context.Request.MapPath(TempDirectory); } }

        static IList<UploadedFilesStorage1> uploadedFilesStorageList;
        static IList<UploadedFilesStorage1> UploadedFilesStorageList
        {
            get
            {
                return uploadedFilesStorageList;
            }
        }

        static UploadControlHelper1()
        {
            uploadedFilesStorageList = new List<UploadedFilesStorage1>();
        }

        static string CreateTempDirectoryCore()
        {
            string uploadDirectory = Path.Combine(RootDirectory, Path.GetRandomFileName());
            Directory.CreateDirectory(uploadDirectory);

            return uploadDirectory;
        }
        public static UploadedFilesStorage1 GetUploadedFilesStorageByKey(string key)
        {
            lock (storageListLocker)
            {
                return GetUploadedFilesStorageByKeyUnsafe(key);
            }
        }
        static UploadedFilesStorage1 GetUploadedFilesStorageByKeyUnsafe(string key)
        {
            UploadedFilesStorage1 storage = UploadedFilesStorageList.Where(i => i.Key == key).SingleOrDefault();
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
                UploadedFilesStorage1 storage = new UploadedFilesStorage1
                {
                    Key = key,
                    Path = CreateTempDirectoryCore(),
                    LastUsageTime = DateTime.Now,
                    Files = new List<UploadedFileInfo1>()
                };
                UploadedFilesStorageList.Add(storage);
            }
        }
        public static void RemoveUploadedFilesStorage(string key)
        {
            lock (storageListLocker)
            {
                UploadedFilesStorage1 storage = GetUploadedFilesStorageByKeyUnsafe(key);
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
                    UploadedFilesStorage1 storage = UploadedFilesStorageList.Where(i => i.Path == directoryPath).SingleOrDefault();
                    if (storage == null || (DateTime.Now - storage.LastUsageTime).TotalMinutes > DisposeTimeout)
                    {
                        Directory.Delete(directoryPath, true);
                        if (storage != null)
                            UploadedFilesStorageList.Remove(storage);
                    }
                }
            }
        }
        public static UploadedFileInfo1 AddUploadedFileInfo(string key, string originalFileName)
        {
            UploadedFilesStorage1 currentStorage = GetUploadedFilesStorageByKey(key);
            UploadedFileInfo1 fileInfo = new UploadedFileInfo1
            {
                FilePath = Path.Combine(currentStorage.Path, Path.GetRandomFileName()),
                OriginalFileName = originalFileName,
                UniqueFileName = GetUniqueFileName(currentStorage, originalFileName)
            };
            currentStorage.Files.Add(fileInfo);

            return fileInfo;
        }
        public static UploadedFileInfo1 GetDemoFileInfo(string key, string fileName)
        {
            UploadedFilesStorage1 currentStorage = GetUploadedFilesStorageByKey(key);
            return currentStorage.Files.Where(i => i.UniqueFileName == fileName).SingleOrDefault();
        }
        public static string GetUniqueFileName(UploadedFilesStorage1 currentStorage, string fileName)
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