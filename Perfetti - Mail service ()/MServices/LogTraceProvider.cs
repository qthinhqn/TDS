

namespace LogTrace
{
    using System;
    using System.Text;
    using System.IO;
    
    public class LogTraceProvider
    {
        public LogTraceProvider()
        {

        }
        public LogTraceProvider(string logFolder)
        {
            logFolderName = logFolder;
        }

        private string errorMessage = "";
        public string ErrorMessage 
        {
            set { errorMessage = value; }
            get { return errorMessage; }
        }

        private string logFolderName = "RCV";
        public string LogFolderName
        {
            set { logFolderName = value; }
            get { return logFolderName; }
        }

        private bool CreateLogFolder()
        {
            bool existFolder = false;
            try
            {
                string folderName = GetLogTraceFilePath();                
                if (!(Directory.Exists(folderName)))
                {
                    DirectoryInfo directoryInfo =
                    Directory.CreateDirectory(folderName);
                }
                existFolder = true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return existFolder;
        }
        public string GetLogTraceFilePath()
        {
            return string.Format("{0}{1}",
            @Environment.GetEnvironmentVariable(
            "TEMP"), "\\RCV");
        }
        private string FormatMessage(string message)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(
            ">>>RCV-[{0}]-{1}",
            DateTime.Now.ToLongDateString() +
            DateTime.Now.ToLongTimeString(), message);
            return stringBuilder.ToString();
        }

        public void WriteErrorToLogFile(string msg)
        {

            StreamWriter streamWriter = null;
            try
            {
                if (CreateLogFolder())
                {
                    using (streamWriter = new
                    StreamWriter(GetLogTraceFilePath() + "\\" +
                    DateTime.Now.ToLongDateString()
                    + ".log", true, Encoding.ASCII, 2048))
                    {
                        TextWriter.Synchronized(streamWriter);
                        streamWriter.WriteLine(FormatMessage(msg));
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }

        }
    }
}
