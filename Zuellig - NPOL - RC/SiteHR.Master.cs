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
    public partial class SiteHR : System.Web.UI.MasterPage
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
                Session["PeriodID"] = KPI_PeriodService.GetKPI_LastActive();
                if (Session["PeriodID"] != null && Session["PeriodID"].ToString() != "0")
                {
                    //S_Ribbon.Tabs[0].Groups[3].Visible = true;
                }
                // Hiện menu Tin tức
                this.liNews.Visible = true;

                //Trường hợp là Admin
                if (Session["Role"].ToString().Equals("HR"))
                {
                    ucLeftMenu.Visible = true;

                    this.liNews.Visible = true;
                    this.liChangePassword.Visible = false;
                    this.liManagerNews.Visible = true;
                    //this.ulAnnual.Visible = false;
                    //this.liRegistration.Visible = false;
                    //this.liApprovalNew.Visible = false;
                    //this.liLeaveReport.Visible = true;
                    //this.ulKPI.Visible = false;
                    //this.likpi4Employee.Visible = false;
                    //this.likpi4Manager.Visible = false;
                    //this.likpiInfo.Visible = false;
                    //this.ulOther.Visible = false;
                    //this.liSalary.Visible = false;
                    //this.li_SkillWill.Visible = false;

                    this.liHRNew.Visible = true;
                    this.limanagerLavelNew.Visible = true;
                    this.liALeaveReport.Visible = true;
                    this.liPassManagement.Visible = true;
                }
                else
                {
                    // Ẩn menu admin
                    ucLeftMenu.Visible = false;
                    tbl_MenuRole menuRole = MenuRoleService.GetInfoByEmpID(sessionEmpID);
                    if(menuRole != null)
                    {
                        this.liNews.Visible = menuRole.News;
                        this.liChangePassword.Visible = menuRole.ChangePassWord;
                        this.liManagerNews.Visible = false;

                        //this.ulAnnual.Visible = true;
                        //this.liRegistration.Visible = menuRole.Registration;
                        //this.liApprovalNew.Visible = menuRole.Approval;
                        //this.liLeaveReport.Visible = menuRole.LeaveReport;

                        //this.ulKPI.Visible = menuRole.KPI4Employee || menuRole.KPI4Manager || menuRole.KPIInfo;
                        //this.likpi4Employee.Visible = menuRole.KPI4Employee;
                        //this.likpi4Manager.Visible = menuRole.KPI4Manager;
                        //this.likpiInfo.Visible = menuRole.KPIInfo;

                        //this.ulOther.Visible = menuRole.Salary || menuRole.Skill_Will;
                        //this.liSalary.Visible = menuRole.Salary;
                        //this.li_SkillWill.Visible = menuRole.Skill_Will;

                        this.liHRNew.Visible = false;// menuRole.HRNew;
                        this.limanagerLavelNew.Visible = false;//menuRole.ManagerLevel;
                        this.liALeaveReport.Visible = false;//menuRole.LeaveReport;
                        this.liPassManagement.Visible = false;//menuRole.PassManagement;
                    }
                    else
                    {
                        this.liNews.Visible = true;
                        this.liChangePassword.Visible = false;
                        this.liManagerNews.Visible = false;
                        //this.ulAnnual.Visible = false;
                        //this.liRegistration.Visible = false;
                        //this.liApprovalNew.Visible = false;
                        //this.liLeaveReport.Visible = true;
                        //this.ulKPI.Visible = false;
                        //this.likpi4Employee.Visible = false;
                        //this.likpi4Manager.Visible = false;
                        //this.likpiInfo.Visible = false;
                        //this.ulOther.Visible = false;
                        //this.liSalary.Visible = false;
                        //this.li_SkillWill.Visible = false;

                        this.liHRNew.Visible = false;
                        this.limanagerLavelNew.Visible = false;
                        this.liALeaveReport.Visible = false;
                        this.liPassManagement.Visible = false;
                    }
                }

            }
            else
            {
                this.ucLeftMenu.Visible = false;
            }
            #endregion

            ////Duy tri trang thai Active Tab cho user
            //if (Session["ActiveTab"] != null)
            //{
            //    int index = Convert.ToInt32(Session["ActiveTab"]);
            //    this.S_Ribbon.ActiveTabIndex = index;
            //}
            //else
            //{
            //    this.S_Ribbon.ActiveTabIndex = 0;
            //}

            //Trinh bay thong tin nhan vien
            if (Session["EmployeeID"] != null)
            {
                ShowEmpInfo(Session["EmployeeID"].ToString());
            }
        }



        public bool IsNewEmp(string EmployeeID)
        {
            bool returnValue = false;
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(conn.ConnectionStrings["ZuelligConnection"].ConnectionString);
                provider.CommandText = "Select Logon_IsNew From tblEmployee Where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                provider.CloseConnection();
                returnValue = Convert.ToBoolean(dt.Rows[0]["Logon_IsNew"]);
            }
            catch
            {
                Response.Redirect("ErrorPage.aspx");
            }
            return returnValue;
        }

        public void ShowEmpInfo(string EmployeeID)
        {
            try
            {
                //khSqlServerProvider provider = new khSqlServerProvider(conn.ConnectionStrings["ZuelligConnection"].ConnectionString);
                //provider.CommandText = "Select EmployeeID, EmployeeName, EmployedDate, PosName, LineName From tblEmployee Where EmployeeID = @EmployeeID";
                //provider.ParameterCollection = new string[] { "@EmployeeID" };
                //provider.ValueCollection = new object[] { EmployeeID };
                //DataTable dt = provider.GetDataTable();
                //if (dt.Rows.Count > 0)
                //{
                //    Label MaNV = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtMaNV");
                //    Label HoTen = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtHoTen");
                //    Label NgayVaoLam = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtNgayVaoLam");
                //    Label ViTri = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtViTri");
                //    Label BoPhan = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtBoPhan");
                //    MaNV.Text = dt.Rows[0]["EmployeeID"].ToString();
                //    HoTen.Text = dt.Rows[0]["EmployeeName"].ToString();
                //    object joined = dt.Rows[0]["EmployedDate"];
                //    if (joined.ToString().Equals(""))
                //    {
                //        NgayVaoLam.Text = "";
                //    }
                //    else
                //    {
                //        NgayVaoLam.Text = ((DateTime)dt.Rows[0]["EmployedDate"]).ToShortDateString();
                //    }
                //    ViTri.Text = dt.Rows[0]["PosName"].ToString();
                //    BoPhan.Text = dt.Rows[0]["LineName"].ToString();
                //}
                //else
                //{
                //    if (Session["Role"].ToString().Equals("HR"))
                //    {
                //        Label MaNV = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtMaNV");
                //        Label HoTen = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtHoTen");
                //        MaNV.Text = Session["EmployeeID"].ToString();
                //        HoTen.Text = Session["EmployeeID"].ToString();
                //    }
                //}
                //provider.CloseConnection();
            }
            catch
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{

        //    string index = HiddenField1.Value.ToString();
        //    switch (index)
        //    {
        //        case "0":
        //            Response.Redirect("~/F_ChangePassWord.aspx");
        //            break;
        //        case "1":
        //            Session["ActiveTab"] = 0;
        //            Response.Redirect("~/F_Registration1.aspx");
        //            break;
        //        case "2":
        //            Response.Redirect("~/F_Registration2.aspx");
        //            break;
        //        case "3":
        //            Response.Redirect("~/F_ViewSalary.aspx");
        //            break;
        //        case "4":
        //            Response.Redirect("~/AF_Approval.aspx");
        //            break;
        //        case "5":
        //            Response.Redirect("~/AF_HR.aspx");
        //            break;
        //        case "6":
        //            Session["ActiveTab"] = 1;
        //            Response.Redirect("~/AF_ManagerLevel.aspx");
        //            break;
        //        case "7":
        //            Session["ActiveTab"] = 1;
        //            Response.Redirect("~/AF_LeaveReport.aspx");
        //            break;
        //        default:
        //            Response.Redirect("~/F_Registration1.aspx");
        //            break;
        //    }
        //}

        protected void S_Ribbon_CommandExecuted(object source, DevExpress.Web.RibbonCommandExecutedEventArgs e)
        {
            string index = e.Item.Name;
            switch (index)
            {
                case "0":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/AF_ChangePassWord.aspx");
                    break;
                case "1":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/F_Registration1.aspx");
                    break;
                case "2":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/F_Registration3.aspx");
                    break;
                case "3":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/F_ViewSalary.aspx");
                    break;
                case "4":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/AF_ApprovalNew.aspx");
                    break;
                case "5":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/AF_HRNew.aspx");
                    break;
                case "6":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/AF_ManagerLevelNew.aspx");
                    break;
                case "7":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/AF_LeaveReport.aspx");
                    break;
                case "8":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/AF_PassManagement.aspx");
                    break;
                    // News
                case "9":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/hrnews.aspx");
                    break;
                case "10":
                    //Session["ActiveTab"] = 0;
                    Response.Redirect("~/SelfAssessmentHistory.aspx");
                    break;
                case "11":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/K_ViewEmpKPI.aspx");
                    break;
                //case "12":
                //    Session["ActiveTab"] = 0;
                //    Response.Redirect("~/N_ListSubmit.aspx");
                //    break;
                //case "13":
                //    Session["ActiveTab"] = 0;
                //    Response.Redirect("~/N_ListAttachment.aspx");
                //    break;
                default:
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/F_Registration1.aspx");
                    break;
            }
        }

        protected void lbtLogout_Click(object sender, EventArgs e)
        {
            Session["ActiveTab"] = 0;
            Response.Redirect("Login.aspx");
        }

        //protected void lbtChangeImage_Click(object sender, EventArgs e)
        //{
        //    ASPxUploadControl1.Visible = true;
        //}

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

        protected void ASPxNavBar1_ItemClick(object source, NavBarItemEventArgs e)
        {
            switch (e.Item.Index)
            {
                case 0:
                    Response.Redirect("~/N_ListNews.aspx");
                    break;
                case 1:
                    Session["NewsID"] = null;
                    Response.Redirect("~/N_MakeNews.aspx");
                    break;
                case 2:
                    Response.Redirect("~/N_ListAttachment.aspx");
                    break;
                case 3:
                    Response.Redirect("~/N_ListSubmit.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void liNew_Click(object sender, EventArgs e)
        {
            Session["NewsID"] = null;
            Response.Redirect("~/N_MakeNews.aspx");
        }
    }
}