using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using conn = System.Web.Configuration.WebConfigurationManager;
using System.Data;
using DevExpress.Web;
using System.IO;
using DevExpress.Web.Internal;
using System.Drawing;
using System.Net;
using NPOL.App_Code.Business;

using NPOL.App_Code.Entities;

namespace NPOL
{
    public partial class SiteRC : System.Web.UI.MasterPage
    {
        public string imagepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionEmpID = null;
            string sessionRole = null;
            Khuong kh = new Khuong(conn.ConnectionStrings["ZuelligConnection"].ConnectionString);

            //Gan session
            if (Session["EmployeeID"] != null)
            {
                sessionEmpID = Session["EmployeeID"].ToString();
            }

            if (Session["Role"] != null)
            {
                sessionRole = Session["Role"].ToString();
            }

            if (!IsPostBack)
            {
                //Hiển thị thông tin đăng nhập
                lbWelcome.Text = GetGlobalResourceObject("F_Registration1", "lbWelcome").ToString();
                lbUserName.Text = kh.getEmployeeName(Session["EmployeeID"].ToString());
            }

            #region Trinh bay Tab
            if (sessionEmpID != null && sessionRole != null)
            {
                // menu KPI
                Session["PeriodID"] = KPI_PeriodService.GetKPI_InProcess();
                if (Session["PeriodID"] != null && Session["PeriodID"].ToString() != "0")
                {
                    //S_Ribbon.Tabs[0].Groups[3].Visible = true;
                }

                //Trường hợp là Admin
                if (Session["Role"].ToString().Equals("RC_Admin"))
                {
                    this.liManagerLevelRC.Visible = true;
                    this.liSynchronizeRC.Visible = true;
                    this.liReportRC.Visible = true;
                }
                else
                {
                    // quay lại trang login
                    Response.Redirect("~/login.aspx");
                }

            }
            #endregion
        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            Session["ActiveTab"] = 0;
            Response.Redirect("Login.aspx");
        }

        protected void ASPxUploadControl1_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            e.CallbackData = SavePostedFile(e.UploadedFile);
        }

        const string UploadDirectory = "~/Images/Pictures/";
        protected string SavePostedFile(UploadedFile uploadedFile)
        {
            string fileName = "";
            if (!uploadedFile.IsValid)
                return string.Empty;
            if (Session["EmployeeID"] != null)
            {
                fileName = Path.ChangeExtension(Session["EmployeeID"].ToString(), ".jpg");
            }
            string fullFileName = CombinePath(fileName);
            using (System.Drawing.Image original = System.Drawing.Image.FromStream(uploadedFile.FileContent))
            using (System.Drawing.Image thumbnail = ImageUtils.CreateThumbnailImage((Bitmap)original, ImageSizeMode.ActualSizeOrFit, new Size(350, 350)))
                ImageUtils.SaveToJpeg((Bitmap)thumbnail, fullFileName);
            //UploadingUtils.RemoveFileWithDelay(fileName, fullFileName, 5);  
            return fileName;
        }
        protected string CombinePath(string fileName)
        {
            return Path.Combine(Server.MapPath(UploadDirectory), fileName);
        }

        public bool URLExists(string url)
        {
            bool result = true;

            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Timeout = 1200; // miliseconds
            webRequest.Method = "HEAD";

            try
            {
                webRequest.GetResponse();
            }
            catch
            {
                result = false;
            }
            return result;
        }

    }
}