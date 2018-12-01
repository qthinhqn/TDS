using DevExpress.Web;
using DevExpress.Web.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using conn = System.Web.Configuration.WebConfigurationManager;

namespace NPOL.UserControl
{
    public partial class EmployeeInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionEmpID = null;
            string sessionRole = null;
            Khuong kh = new Khuong(conn.ConnectionStrings["ZuelligConnection"].ConnectionString);

            //Gan session
            if (Session["EmployeeID"] != null)
            {
                sessionEmpID = Session["EmployeeID"].ToString();
                System.Web.UI.WebControls.Image img = ASPxNavBar1.Groups[0].Items[0].FindControl("Image1") as System.Web.UI.WebControls.Image;
                
                //Tải hình ảnh lên 
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
        }

        public void ShowEmpInfo(string EmployeeID)
        {
            try
            {
                khSqlServerProvider provider = new khSqlServerProvider(conn.ConnectionStrings["ZuelligConnection"].ConnectionString);
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
    }
}