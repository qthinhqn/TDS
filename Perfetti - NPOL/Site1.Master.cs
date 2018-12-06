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


namespace NPOL
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string imagepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionEmpID = null;
            string sessionRole = null;
            Khuong kh = new Khuong(conn.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);

            //Gan session
            if (Session["EmployeeID"] != null)
            {
                sessionEmpID = Session["EmployeeID"].ToString();
                System.Web.UI.WebControls.Image img = ASPxNavBar1.Groups[0].Items[0].FindControl("Image1") as System.Web.UI.WebControls.Image;
                //img.Dispose();

                //try
                //{
                //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:1896/Images/Pictures/" + sessionEmpID + ".jpg");
                //    request.Credentials = System.Net.CredentialCache.DefaultCredentials;
                //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    img.ImageUrl = "http://localhost:1896/Images/Pictures/" + sessionEmpID + ".jpg";
                //}
                //catch
                //{
                //    // image doesn't exist, set to default picture
                //    img.ImageUrl = "http://localhost:1896/Images/Pictures/employee.jpg";
                //}


                //if (URLExists("http://eleave.vn.pvmgrp.com/Images/Pictures/" + sessionEmpID + ".jpg") || URLExists("https://eleave.vn.pvmgrp.com/Images/Pictures/" + sessionEmpID + ".jpg")
                //    || URLExists("http://hrmweb.vn.pvmgrp.com/eleave/Images/Pictures/" + sessionEmpID + ".jpg") || URLExists("https://hrmweb.vn.pvmgrp.com/eleave/Images/Pictures/" + sessionEmpID + ".jpg"))
                //{
                //    img.ImageUrl = "Images/Pictures/" + sessionEmpID + ".jpg";
                //}
                //else
                //{
                //    img.ImageUrl = "Images/Pictures/employee.jpg";
                //}

                //img.DataBind();

                //Tải hình ảnh lên Left Menu
                string serverPath = Server.MapPath("~/Images/Pictures/") + Path.GetFileName("~/Images/Pictures/" + sessionEmpID + ".jpg");
                if (File.Exists(serverPath))
                {
                    img.ImageUrl = "~/Images/Pictures/" + sessionEmpID + ".jpg";
                }
                else
                {
                    img.ImageUrl = "Images/Pictures/employee.jpg";
                }


            }

            if (Session["Role"] != null)
            {
                sessionRole = Session["Role"].ToString();
            }

            //Trinh bay Tab
            if (sessionEmpID != null && sessionRole != null)
            {
                S_Ribbon.Tabs[1].Groups[5].Visible = false;

                if ((sessionRole.Substring(0, 1)).Equals("E"))
                {
                    //Trường hợp là nhân viên mới
                    if (sessionRole.Equals("E1"))
                    {
                        S_Ribbon.Tabs[0].Visible = false;
                        S_Ribbon.Tabs[1].Visible = false;
                        //S_Ribbon.ShowFileTab = false;
                    }

                    //Trường hợp là nhân viên cũ
                    if (sessionRole.Equals("E2"))
                    {
                        S_Ribbon.Tabs[0].Visible = true;
                        S_Ribbon.Tabs[1].Visible = false;
                        //S_Ribbon.ShowFileTab = true;
                    }

                }

                //Trường hợp vừa là Manager vừa là Employee
                if (sessionRole.Substring(0, 1).Equals("M") && (Session["MID1"] != null || Session["MID2"] != null || Session["MID3"] != null))
                {
                    S_Ribbon.Tabs[0].Visible = true;
                    S_Ribbon.Tabs[0].Groups[1].Visible = true;
                    S_Ribbon.Tabs[0].Groups[2].Visible = true;
                    S_Ribbon.Tabs[1].Visible = true;
                    S_Ribbon.Tabs[1].Groups[1].Visible = false;
                    S_Ribbon.Tabs[1].Groups[2].Visible = false;
                    S_Ribbon.Tabs[1].Groups[3].Visible = false; 
                    S_Ribbon.Tabs[1].Groups[5].Visible = true;
                    //S_Ribbon.ShowFileTab = true;
                }

                //Trường hợp chỉ là Manager
                else if ((sessionRole.Substring(0, 1)).Equals("M"))
                {
                    //S_Ribbon.ShowFileTab = false;
                    S_Ribbon.Tabs[0].Visible = true;
                    S_Ribbon.Tabs[0].Groups[1].Visible = false;
                    S_Ribbon.Tabs[0].Groups[2].Visible = false;
                    S_Ribbon.Tabs[1].Visible = true;
                    S_Ribbon.Tabs[1].Groups[1].Visible = false;
                    S_Ribbon.Tabs[1].Groups[2].Visible = false;
                    S_Ribbon.Tabs[1].Groups[3].Visible = false;
                    S_Ribbon.Tabs[1].Groups[5].Visible = true;
                }

                //Trường hợp là Admin
                if (Session["Role"].ToString().Equals("HR"))
                {
                    //S_Ribbon.ShowFileTab = false;
                    S_Ribbon.Tabs[0].Visible = true;
                    S_Ribbon.Tabs[0].Groups[1].Visible = false;
                    S_Ribbon.Tabs[0].Groups[2].Visible = false;
                    S_Ribbon.Tabs[1].Visible = true;
                    S_Ribbon.Tabs[1].Groups[0].Visible = false;
                    S_Ribbon.Tabs[1].Groups[4].Visible = true;
                }

            }
            else
            {
                //S_Ribbon.ShowFileTab = false;
                S_Ribbon.Tabs[0].Visible = false;
                S_Ribbon.Tabs[1].Visible = false;
            }


            //Duy tri trang thai Active Tab cho user
            if (Session["ActiveTab"] != null)
            {
                int index = Convert.ToInt32(Session["ActiveTab"]);
                this.S_Ribbon.ActiveTabIndex = index;
            }
            else
            {
                this.S_Ribbon.ActiveTabIndex = 0;
            }

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
                khSqlServerProvider provider = new khSqlServerProvider(conn.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
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
                khSqlServerProvider provider = new khSqlServerProvider(conn.ConnectionStrings["PERFETTIConnectionString"].ConnectionString);
                provider.CommandText = "Select EmployeeID, EmployeeName, EmployedDate, PosName, LineName From tblEmployee Where EmployeeID = @EmployeeID";
                provider.ParameterCollection = new string[] { "@EmployeeID" };
                provider.ValueCollection = new object[] { EmployeeID };
                DataTable dt = provider.GetDataTable();
                if (dt.Rows.Count > 0)
                {
                    Label MaNV = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtMaNV");
                    Label HoTen = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtHoTen");
                    Label NgayVaoLam = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtNgayVaoLam");
                    Label ViTri = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtViTri");
                    Label BoPhan = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtBoPhan");
                    MaNV.Text = dt.Rows[0]["EmployeeID"].ToString();
                    HoTen.Text = dt.Rows[0]["EmployeeName"].ToString();
                    object joined = dt.Rows[0]["EmployedDate"];
                    if (joined.ToString().Equals(""))
                    {
                        NgayVaoLam.Text = "";
                    }
                    else
                    {
                        NgayVaoLam.Text = ((DateTime)dt.Rows[0]["EmployedDate"]).ToShortDateString();
                    }
                    ViTri.Text = dt.Rows[0]["PosName"].ToString();
                    BoPhan.Text = dt.Rows[0]["LineName"].ToString();
                }
                else
                {
                    if (Session["Role"].ToString().Equals("HR"))
                    {
                        Label MaNV = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtMaNV");
                        Label HoTen = (Label)ASPxNavBar1.Groups[0].Items[0].FindControl("txtHoTen");
                        MaNV.Text = Session["EmployeeID"].ToString();
                        HoTen.Text = Session["EmployeeID"].ToString();
                    }
                }
                provider.CloseConnection();
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
                    Response.Redirect("~/F_ChangePassWord.aspx");
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
                case "3.2":
                    Session["ActiveTab"] = 0;
                    Response.Redirect("~/F_ViewIncomeTax.aspx");
                    break;
                case "4":
                    Session["ActiveTab"] = 1;
                    Response.Redirect("~/AF_ApprovalNew.aspx");
                    break;
                case "5":
                    Session["ActiveTab"] = 1;
                    Response.Redirect("~/AF_HRNew.aspx");
                    break;
                case "6":
                    Session["ActiveTab"] = 1;
                    Response.Redirect("~/AF_ManagerLevelNew.aspx");
                    break;
                case "7":
                    Session["ActiveTab"] = 1;
                    Response.Redirect("~/AF_LeaveReport.aspx");
                    break;
                case "8":
                    Session["ActiveTab"] = 1;
                    Response.Redirect("~/AF_PassManagement.aspx");
                    break;
                case "9":
                    Session["ActiveTab"] = 1;
                    Response.Redirect("~/F_LeaveReport_New.aspx");
                    break;
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
    }
}