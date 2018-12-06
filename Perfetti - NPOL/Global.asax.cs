using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;
using System.Globalization;


namespace NPOL
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            //string connectionString = ConnectionHelper.ConnectionString;
            //DevExpress.Xpo.Metadata.XPDictionary dictionary = new DevExpress.Xpo.Metadata.ReflectionDictionary();
            //DevExpress.Xpo.DB.IDataStore store = DevExpress.Xpo.XpoDefault.GetConnectionProvider(connectionString, DevExpress.Xpo.DB.AutoCreateOption.SchemaAlreadyExists);
            //dictionary.GetDataStoreSchema(typeof(Northwind.Products).Assembly);
            //DevExpress.Xpo.XpoDefault.DataLayer = new DevExpress.Xpo.ThreadSafeDataLayer(dictionary, store);
            //DevExpress.Xpo.XpoDefault.Session = null;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //HttpCookie ckUser = Request.Cookies["Username"];
            //HttpCookie ckPass = Request.Cookies["Password"];
            //HttpCookie Name = Request.Cookies["NameEmpl"];

            //if ((ckUser != null) && (ckPass != null))
            //{

            //    Session["EmployeeID"] = ckUser.Value.ToString();
            //    Session["NameEmployee"] = Name.Value.ToString();

            //    Session["Logon_Password"] = ckPass.Value.ToString();
            //    Response.Redirect("F_Registration1.aspx");
            //}
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //if (HttpContext.Current.Request.IsSecureConnection.Equals(false))
            //{
            //    Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.RawUrl);
            //} 
            
            HttpCookie cookie = Request.Cookies["CultureInfo"];

            if (cookie != null && cookie.Value != null)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(cookie.Value);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(cookie.Value);
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}