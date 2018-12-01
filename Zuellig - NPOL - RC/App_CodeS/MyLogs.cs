using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

public class MyLogs
{
    static string path = AppDomain.CurrentDomain.BaseDirectory + @"Logs\";
    static string filename = "MailServiceLog.txt";

    public static void CreateLogFile()
    {
        if (!Directory.Exists(path))
        {
            // Create directory
            System.IO.Directory.CreateDirectory(path);
        }
        if (!File.Exists(path + filename))
        {
            // Create logfile
            FileStream fs = System.IO.File.Create(path + filename);
            fs.Close();
        }
    }

    public static void LogError(Exception ex)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Error: {0}", ex.Message);
        message += Environment.NewLine;
        message += string.Format("StackTrace: {0}", ex.StackTrace);
        message += Environment.NewLine;
        message += string.Format("Source: {0}", ex.Source);
        message += Environment.NewLine;
        message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        using (StreamWriter writer = new StreamWriter(path + filename, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }

    public static void LogInfo(string info)
    {
        string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        message += string.Format("Info: {0}", info);
        message += Environment.NewLine;
        message += "-----------------------------------------------------------";
        message += Environment.NewLine;
        using (StreamWriter writer = new StreamWriter(path + filename, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }
}