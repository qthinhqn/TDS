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
        set { 
                if(value == "")
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
        get {return mailAddress;}
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
            ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2013);
            //service.AutodiscoverUrl("youremailaddress@yourdomain.com");
            //uri = "https://mail.namkimgroup.vn/ews/Exchange.asmx";
            service.Url = new Uri(uri);
            service.UseDefaultCredentials = true;
            service.Credentials = new WebCredentials(username, pass);
            EmailMessage message = new EmailMessage(service);
            message.ToRecipients.Add(emailTo);
            message.Subject = subject;
            message.Body = body;            
            message.Send();
        }
        catch (Exception ex)
        {
            sendSuccessful = false;
            errorMessage = ex.Message;
        }
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
	    catch(Exception ex)
	    {
            sendSucessful = false;
	        errorMessage=ex.Message;
	        
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
            if(emailCC != "")
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
            if(emailCC != "")
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
            if(emailCC != "")
                mailMessage.CC.Add(emailCC);
            if (emailBCC != "")
                mailMessage.Bcc.Add(emailBCC);
            mailMessage.Body = body;
            if (attachFileName != null)
            {
                foreach(string fileName in attachFileName)
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
    string  attachFileName)
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
}
