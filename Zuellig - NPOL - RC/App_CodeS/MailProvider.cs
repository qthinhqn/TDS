using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.Exchange.WebServices.Data;

/// <summary>
/// Summary description for MailClass
/// </summary>
public class MailProvider
{
    public MailProvider()
    {
        //mailAddress = new
        //MailAddress("khuongsm@gmail.com");
    }

    //public MailProvider(string mailServerName)
    //{
    //    hostServerName = mailServerName;
    //    mailAddress = new
    //    MailAddress("khuongsm@gmail.com");        
    //} 
    private int port = 0;
    public int Port
    {
        set { port = value; }
        get { return port; }
    }

    private string mailServerName = "smtp.gmail.com";
    public string MailServerName
    {
        set
        {
            if (value == "")
                mailServerName = "smtp.gmail.com";
            else
                mailServerName = value;
        }
        get { return mailServerName; }
    }

    private string mailAddress = null;
    public string MailAddress
    {
        set { mailAddress = value; }
        get { return mailAddress; }
    }



    private string errorMessage = "";
    public string ErrorMessage
    {
        set { errorMessage = value; }
        get { return errorMessage; }
    }


    public bool SendMailFromExchange(string emailTo, string subject, string body, string username, string pass, string uri)
    {
        bool sendSuccessful = true;
        try
        {
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
            //service.AutodiscoverUrl("youremailaddress@yourdomain.com");
            //uri = "https://mail.namkimgroup.vn/ews/Exchange.asmx";
            service.Url = new Uri(uri);
            service.UseDefaultCredentials = true;
            service.Credentials = new WebCredentials(username, pass);
            EmailMessage message = new EmailMessage(service);
            message.ToRecipients.Add(emailTo);
            message.Subject = subject;

            body += Signature();
            string strImgPath = AppDomain.CurrentDomain.BaseDirectory + @"images\HR_Sign.png";
            FileAttachment attachment = message.Attachments.AddFileAttachment(strImgPath);
            // Add attachmentid.
            attachment.ContentId = "myImageID";

            message.Body = body;
            message.Send();
        }
        catch (Exception ex)
        {
            sendSuccessful = false;
            errorMessage = ex.Message;
            MyLogs.LogError(ex);
        }
        return sendSuccessful;
    }
    public static bool MySendMailFromExchange(string emailTo, string subject, string body, string username, string pass, string host)
    {
        bool sendSuccessful = true;
        try
        {
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(host);

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            //mail.Body = strMessage;
            mail.IsBodyHtml = true;
            mail.To.Add(emailTo);
            mail.Subject = subject;

            mail.From = new System.Net.Mail.MailAddress(username + "@zuelligpharma.com");
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential(username, pass);
            smtp.UseDefaultCredentials = false;
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = cred;
            smtp.Send(mail);
        }
        catch (Exception ex)
        {
            sendSuccessful = false;
            //errorMessage = ex.Message;
            //WriteErrorToFile(ex);
        }

        return sendSuccessful;
    }

    public static bool MySendMailFromExchange2(string emailTo, string subject, string body, string username, string pass, string host)
    {
        bool sendSuccessful = true;
        string sMessage = "";
        try
        {
            SmtpClient smtpClient = new SmtpClient();
            MailMessage message = new MailMessage();
            try
            {

                //you can provide invalid from address. but to address Should be valil
                MailAddress fromAddress = new MailAddress(username + "@zuelligpharma.com");

                smtpClient.Host = host;
                smtpClient.Port = 25;
                //smtpClient.Port = 587;


                smtpClient.UseDefaultCredentials = true;

                message.From = fromAddress;
                message.To.Add(emailTo); //Recipent email 
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;

                //smtpClient.EnableSsl = true; 

                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtpClient.Send(message);

                sMessage = "Email sent.";
            }
            catch (Exception ex)
            {
                sMessage = "Coudn't send the message!\n " + ex.Message;
            }
        }
        catch (Exception ex)
        {
            sendSuccessful = false;
            //errorMessage = ex.Message;
            //WriteErrorToFile(ex);
        }
        //MyLogs.LogInfo(sMessage);
        return sendSuccessful;
    }

    public bool SendMailFromGmail(string emailTo, string subject, string body, string username, string pass)
    {
        bool sendSuccessful = true;
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailAddress);
            mailMessage.To.Add(emailTo);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient = new SmtpClient(mailServerName);
            smtpClient.Port = port;
            //smtpClient.Port = 587;
            //smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(username, pass);
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            sendSuccessful = false;
            errorMessage = ex.Message;
        }

        return sendSuccessful;
    }

    public bool SendMail(string emailTo, string subject, string body)
    {
        bool sendSucessful = true;
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailAddress);
            mailMessage.To.Add(emailTo);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient =
            new SmtpClient(mailServerName);
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            sendSucessful = false;
            errorMessage = ex.Message;

        }
        return sendSucessful;
    }

    public bool SendMail(
    string emailTo, string emailCC,
    string emailBCC, string subject, string body)
    {
        bool sendSucessful = true;
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailAddress);
            mailMessage.To.Add(emailTo);
            mailMessage.Subject = subject;
            if (emailCC != "")
                mailMessage.CC.Add(emailCC);
            if (emailBCC != "")
                mailMessage.Bcc.Add(emailBCC);
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient =
            new SmtpClient(mailServerName);
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            sendSucessful = false;
            errorMessage = ex.Message;

        }
        return sendSucessful;
    }

    public bool SendMail(
    string emailTo, string emailCC,
    string emailBCC, string subject,
    string body, string attachFileName)
    {
        bool sendSucessful = true;
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailAddress);
            mailMessage.To.Add(emailTo);
            mailMessage.Subject = subject;
            if (emailCC != "")
                mailMessage.CC.Add(emailCC);
            if (emailBCC != "")
                mailMessage.Bcc.Add(emailBCC);
            mailMessage.Body = body;
            if (attachFileName != "")
            {
                System.Net.Mail.Attachment attachment =
                new System.Net.Mail.Attachment(attachFileName);
                mailMessage.Attachments.Add(attachment);
            }
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient =
            new SmtpClient(mailServerName);
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            sendSucessful = false;
            errorMessage = ex.Message;

        }
        return sendSucessful;
    }

    public bool SendMail(
    string emailTo, string emailCC,
    string emailBCC, string subject,
    string body, string[] attachFileName)
    {
        bool sendSucessful = true;
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mailAddress);
            mailMessage.To.Add(emailTo);
            mailMessage.Subject = subject;
            if (emailCC != "")
                mailMessage.CC.Add(emailCC);
            if (emailBCC != "")
                mailMessage.Bcc.Add(emailBCC);
            mailMessage.Body = body;
            if (attachFileName != null)
            {
                foreach (string fileName in attachFileName)
                {
                    AttachFile(mailMessage, fileName);
                }
            }
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient =
            new SmtpClient(mailServerName);
            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            sendSucessful = false;
            errorMessage = ex.Message;

        }
        return sendSucessful;
    }

    void AttachFile(MailMessage mailMessage,
    string attachFileName)
    {
        if (attachFileName != "")
        {
            using (System.Net.Mail.Attachment attachment =
                new System.Net.Mail.Attachment(attachFileName))
            {
                mailMessage.Attachments.Add(attachment);
            }
        }

    }

    public bool IsEmail(string inputEmail)
    {
        if (inputEmail == null | inputEmail.Length > 35) return false;
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
            @".)+))([a-zA-Z]{2,6}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        return (re.IsMatch(inputEmail));
    }

    public static string Signature()
    {
        string sign = "";

        sign += "<p>&nbsp;</p>";

        sign += "<p><span style=\"font-size:10.0pt;font-family:&quot;Lucida Sans&quot;,&quot;sans-serif&quot;;color:#117577\">HR Department";
        sign += "<br><br></span>";
        sign += "<span style=\"font-size:10.0pt;font-family:&quot;Lucida Sans&quot;,&quot;sans-serif&quot;;color:black\">Zuellig Pharma Vietnam Ltd.";
        sign += "<br></span>";
        sign += "<span style=\"font-size:10.0pt;font-family:&quot;Lucida Sans&quot;,&quot;sans-serif&quot;;color:#212121\">TNR Tower Nguyen Cong Tru, Level 5";
        sign += "<br></span>";
        sign += "<span style=\"font-size:10.0pt;font-family:&quot;Lucida Sans&quot;,&quot;sans-serif&quot;;color:#212121\">180 - 192 Nguyen Cong Tru St., Dist.1&nbsp;I&nbsp;Ho Chi Minh City I Vietnam<br></span>";
        sign += "<span style=\"font-size:10.0pt;font-family:&quot;Lucida Sans&quot;,&quot;sans-serif&quot;;color:black\">Tel &#43;848 3910 2650<br></span>";
        sign += "<span style=\"font-size:10.0pt;font-family:&quot;Lucida Sans&quot;,&quot;sans-serif&quot;;color:black\"><a href=\"mailto:vnzp-hr@zuelligpharma.com\">vnzp-hr@zuelligpharma.com</a><br></span>";
        sign += "<span style=\"font-size:10.0pt;font-family:&quot;Lucida Sans&quot;,&quot;sans-serif&quot;;color:black\"><a href=\"http://www.zuelligpharma.com/\"><span style=\"color:black\">www.zuelligpharma.com</span></a><br></span>";
        sign += "</p>";
        sign += "<p><img border=\"0\" width=\"623\" height=\"25\" id=\"signature_image\" src=\"cid:myImageID\" alt=\"ZP_EMAIL_SIGNATURE_RGB\"></p>";

        sign += "<p>&nbsp;</p>";

        return sign;
    }
}
