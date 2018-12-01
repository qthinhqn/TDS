using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using cur = System.Web.HttpContext;
using Ionic.Zip;

namespace PAOL.App_Code.Business
{
    public class Utility
    {
        public static void DownloadFile_v2(string strPath, string filename)
        {
            try
            {
                string path = cur.Current.Server.MapPath(strPath);
                System.IO.FileInfo file = new System.IO.FileInfo(path);
                if (file.Exists)
                {
                    cur.Current.Response.Clear();
                    cur.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
                    cur.Current.Response.AddHeader("Content-Length", file.Length.ToString());
                    cur.Current.Response.ContentType = "application/octet-stream";
                    cur.Current.Response.WriteFile(file.FullName);
                    cur.Current.Response.End();
                }
                else
                {
                    cur.Current.Response.Write("This file does not exist.");
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void Download_A_File(string strPath, string fileName)
        {
            string path = cur.Current.Server.MapPath(strPath);
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] bt = new byte[fs.Length];
            fs.Read(bt, 0, (int)fs.Length);
            fs.Close();
            cur.Current.Response.ContentType = "application/x-unknown/octet-stream";
            cur.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
            try
            {
                if (bt != null)
                {
                    System.IO.MemoryStream stream1 = new System.IO.MemoryStream(bt, true);
                    stream1.Write(bt, 0, bt.Length);
                    cur.Current.Response.BinaryWrite(bt);
                    //Response.OutputStream.Write(bt, 0, (int)stream1.Length);
                    cur.Current.Response.Flush();
                    // Response.End();
                }
            }
            catch (Exception ex)
            {
                cur.Current.Response.Write(ex.Message);
                throw ex;
            }
            finally
            {
                //cur.Current.Response.End();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }

        public static void Download_Multy_Files(List<object> selectedRows)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AlternateEncodingUsage = ZipOption.AsNecessary;
                zip.AddDirectoryByName("Files");
                foreach (object item in selectedRows)
                {
                    object[] arr = item as object[];
                    string filePath = arr[0].ToString();
                    filePath = cur.Current.Server.MapPath(filePath);
                    zip.AddFile(filePath, "Files");
                }
               cur.Current.Response.Clear();
               cur.Current.Response.BufferOutput = false;
                string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                cur.Current.Response.ContentType = "application/zip";
                cur.Current.Response.AddHeader("content-disposition", "attachment; filename=" + zipName);
                zip.Save(cur.Current.Response.OutputStream);
                cur.Current.Response.End();
                //HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        /*
            string source = "Hello World!";
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, source);

                Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

                Console.WriteLine("Verifying the hash...");

                if (VerifyMd5Hash(md5Hash, source, hash))
                {
                    Console.WriteLine("The hashes are the same.");
                }
                else
                {
                    Console.WriteLine("The hashes are not same.");
                }
            }
         */
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public class ToRomanNumber
    {
        string s = "";

        public string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999))
            {
                s = s + "Invalid Input";
            }
            if (number < 1) return s;
            if (number >= 1000) { s = s + "M"; ToRoman(number - 1000); }
            else if (number >= 900) { s = s + "CM"; ToRoman(number - 900); }
            else if (number >= 500) { s = s + "D"; ToRoman(number - 500); }
            else if (number >= 400) { s = s + "CD"; ToRoman(number - 400); }
            else if (number >= 100) { s = s + "C"; ToRoman(number - 100); }
            else if (number >= 90) { s = s + "XC"; ToRoman(number - 90); }
            else if (number >= 50) { s = s + "L"; ToRoman(number - 50); }
            else if (number >= 40) { s = s + "XL"; ToRoman(number - 40); }
            else if (number >= 10) { s = s + "X"; ToRoman(number - 10); }
            else if (number >= 9) { s = s + "IX"; ToRoman(number - 9); }
            else if (number >= 5) { s = s + "V"; ToRoman(number - 5); }
            else if (number >= 4) { s = s + "IV"; ToRoman(number - 4); }
            else if (number >= 1) { s = s + "I"; ToRoman(number - 1); }
            return s;
        }
    }
}