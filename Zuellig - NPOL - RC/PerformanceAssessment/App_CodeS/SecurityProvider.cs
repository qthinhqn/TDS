using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

/// <summary>
/// Summary description for SecurityProvider
/// </summary>
public class SecurityProvider
{

    public SecurityProvider()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private string keyValue = "RCV";
    public string Key
    {
        set { keyValue = value; }
        get { return keyValue; }
    }

    public string RCVEncPwd(string password)
    {
        string encryptPassword = password + keyValue;
        byte[] passwordBytes = Encoding.UTF8.GetBytes(encryptPassword);

        HashAlgorithm hash = new MD5CryptoServiceProvider();
        byte[] hashBytes = hash.ComputeHash(passwordBytes);

        encryptPassword = Convert.ToBase64String(passwordBytes);
        return encryptPassword;
    }
    public string RCVDecPwd(string password)
    {
        string originalPassword = "";
        byte[] inputByteArray = Convert.FromBase64String(password);

        originalPassword = Encoding.UTF8.GetString(inputByteArray);

        return originalPassword.Substring(0,
        originalPassword.Length - keyValue.Length);
    }
    byte[] RandomBytes(int minSize, int maxSize)
    {
        Random random = new Random();
        int randomNumber = random.Next(minSize, maxSize);
        byte[] randomBytes = new byte[randomNumber];
        RNGCryptoServiceProvider rngCryptoServiceProvider
        = new RNGCryptoServiceProvider();
        rngCryptoServiceProvider.GetNonZeroBytes(randomBytes);
        return randomBytes;
    }
    private string Encrypt(string strToEncrypt)
    {
        try
        {
            Byte[] bytKey = System.Text.Encoding.UTF8.GetBytes(Key);
            Byte[] bytIV = System.Text.Encoding.UTF8.GetBytes(Key);
            TripleDESCryptoServiceProvider objTripleDES = new TripleDESCryptoServiceProvider();
            byte[] bytInput = Encoding.UTF8.GetBytes(strToEncrypt);
            MemoryStream objOutputStream = new MemoryStream();
            CryptoStream objCryptoStream = new CryptoStream(objOutputStream, objTripleDES.CreateEncryptor(bytKey, bytIV), CryptoStreamMode.Write);
            objCryptoStream.Write(bytInput, 0, bytInput.Length);
            objCryptoStream.FlushFinalBlock();
            return Convert.ToBase64String(objOutputStream.ToArray());
        }
        catch (Exception ExceptionErr)
        {
            throw new System.Exception(ExceptionErr.Message, ExceptionErr.InnerException);
        }
    }

    private string Decrypt(string strToDecrypt)
    {
        try
        {
            Byte[] bytKey = System.Text.Encoding.UTF8.GetBytes(Key);
            Byte[] bytIV = System.Text.Encoding.UTF8.GetBytes(Key);
            TripleDESCryptoServiceProvider objTripleDES = new TripleDESCryptoServiceProvider();
            byte[] inputByteArray = Convert.FromBase64String(strToDecrypt);
            MemoryStream objOutputStream = new MemoryStream();
            CryptoStream objCryptoStream = new CryptoStream(objOutputStream, objTripleDES.CreateDecryptor(bytKey, bytIV), CryptoStreamMode.Write);
            objCryptoStream.Write(inputByteArray, 0, inputByteArray.Length);
            objCryptoStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(objOutputStream.ToArray());
        }
        catch (Exception ExceptionErr)
        {
            throw new System.Exception(ExceptionErr.Message, ExceptionErr.InnerException);
        }
    }
}
