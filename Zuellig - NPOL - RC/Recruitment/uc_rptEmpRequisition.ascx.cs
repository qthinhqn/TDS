using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using NPOL.App_Code.Business;
using NPOL.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NPOL.UserControl
{
    public partial class uc_rptEmpRequisition : System.Web.UI.UserControl
    {
        public class ThumbnailsFiller : BookmarkFillerBase<Control>
        {
            public static void FillThumbnails(ASPxPanel panel, ASPxDocumentViewer documentViewer)
            {
                //new ThumbnailsFiller(documentViewer).Fill(panel);
            }
            protected override Document Document
            {
                get
                {
                    var printingSystem = documentViewer.Report.PrintingSystem;
                    if (printingSystem.PageCount == 0)
                    {
                        documentViewer.Report.CreateDocument();
                    }
                    return printingSystem.Document;
                }
            }

            ASPxDocumentViewer documentViewer;

            ThumbnailsFiller(ASPxDocumentViewer documentViewer)
                : base(documentViewer.ClientID)
            {
                this.documentViewer = documentViewer;
            }

            protected override Control FillNode(Control parent, BookmarkNode bookmarkNode, string navigationScript)
            {
                ASPxPanel aspxPanel = parent as ASPxPanel;
                if (aspxPanel != null)
                {
                    PlaceHolder holder = new PlaceHolder();
                    aspxPanel.Controls.Add(holder);
                    return holder;
                }

                ImageBrick imageBrick = bookmarkNode.Brick as ImageBrick;
                if (imageBrick != null)
                {
                    string fileName = bookmarkNode.Text + ".png";
                    string filePath = HttpContext.Current.Server.MapPath("~/images/Employee_1.jpg");// + fileName);
                    if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    try
                    {
                        if (!File.Exists(filePath))
                            imageBrick.Image.Save(filePath, ImageFormat.Jpeg);
                    }
                    catch (System.Runtime.InteropServices.ExternalException) { }

                    Image image = new Image();
                    image.BorderColor = imageBrick.BorderColor;
                    image.BorderWidth = new Unit(imageBrick.BorderWidth, UnitType.Pixel);
                    image.AlternateText = bookmarkNode.Text;
                    image.ImageUrl = new Uri(parent.Page.Request.Url, "ThumbnailsImageHandler.ashx?img=" + System.Web.HttpUtility.UrlEncode(fileName)).ToString();
                    image.Width = new Unit(imageBrick.Image.Width / 2, UnitType.Pixel);
                    image.Height = new Unit(imageBrick.Image.Height / 2, UnitType.Pixel);

                    LiteralControl fullName = new LiteralControl();
                    fullName.Text = bookmarkNode.Text;

                    HtmlAnchor anchor = new HtmlAnchor();
                    anchor.HRef = "javascript:void(" + navigationScript + ")";
                    anchor.Controls.Add(image);
                    anchor.Controls.Add(new LiteralControl("<br />"));
                    anchor.Controls.Add(fullName);

                    WebControl div = new WebControl(HtmlTextWriterTag.Div);
                    div.Style["margin-left"] = "10px";
                    div.Style["margin-top"] = "10px";
                    div.Style["margin-bottom"] = "20px";
                    div.Style["text-align"] = "center";
                    div.Controls.Add(anchor);

                    parent.Controls.Add(div);
                }
                return null;
            }
        }


        private string requestID;
        public string RequestID
        {
            get
            {
                return requestID;
            }
            set
            {
                requestID = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void Page_Init(object sender, EventArgs e)
        public void ReloadControl()
        {
            //var report = new Report
            //{
            //    PaperKind = PaperKind.A5,
            //    Landscape = true
            //};

            Recruit_ApprovalService service = new Recruit_ApprovalService();
            DataTable dt = service.GetTable_rptEmpRequisition("spRC_Print_PersonnelRequisition", this.requestID);

            if (dt != null & dt.Rows.Count>0)
            {
                string result = service.getReportType(requestID);
                if (result == "1")
                {
                    var report = new Xtra_PersonnelRequisition_Full();
                    //report.DataSource = dt;


                    report.Parameters["RequestID"].Value = this.requestID;

                    //XRSubreport detailReport = report.Bands[BandKind.Detail].FindControl("xrSubreport1", true) as XRSubreport;
                    ////detailReport.ReportSource.DataSource = service.GetTable_SubrptEmpKPI(dt.Rows[0]["EmployeeID"].ToString(), this.periodid);
                    //detailReport.ReportSource.DataSource = service.GetTable_rptEmpKPI("spKPI_Subrpt_EmployeeInfo", this.employeeid, this.periodid);

                    //XRSubreport detailReport2 = report.Bands[BandKind.Detail].FindControl("xrSubreport2", true) as XRSubreport;
                    //detailReport2.ReportSource.DataSource = service.GetTable_rptEmpKPI("spKPI_subrpt_CompetencyInfo", this.employeeid, this.periodid);

                    //report.Margins.Left = 90;
                    //report.Margins.Right = 85;
                    report.xrPictureBox1.BeforePrint += xrPictureBox1_BeforePrint;

                    //report.RequestParameters = false;
                    documentViewer.Report = report;
                }
                else if (result == "2")
                {
                    //var report = new Xtra_PromotionAdjustment();
                    var report = new Xtra_PromotionAdjustment();
                    //report.DataSource = dt;


                    report.Parameters["RequestID"].Value = this.requestID;
                    report.Parameters["UserID"].Value = Session["EmployeeID"];

                    //XRSubreport detailReport = report.Bands[BandKind.Detail].FindControl("xrSubreport1", true) as XRSubreport;
                    ////detailReport.ReportSource.DataSource = service.GetTable_SubrptEmpKPI(dt.Rows[0]["EmployeeID"].ToString(), this.periodid);
                    //detailReport.ReportSource.DataSource = service.GetTable_rptEmpKPI("spKPI_Subrpt_EmployeeInfo", this.employeeid, this.periodid);

                    //XRSubreport detailReport2 = report.Bands[BandKind.Detail].FindControl("xrSubreport2", true) as XRSubreport;
                    //detailReport2.ReportSource.DataSource = service.GetTable_rptEmpKPI("spKPI_subrpt_CompetencyInfo", this.employeeid, this.periodid);

                    //report.Margins.Left = 90;
                    //report.Margins.Right = 85;
                    report.xrPictureBox1.BeforePrint += xrPictureBox1_BeforePrint;

                    //report.RequestParameters = false;
                    documentViewer.Report = report;
                }

            }
            
            
        }

        protected override void OnPreRender(EventArgs e)
        {
            //ThumbnailsFiller.FillThumbnails(Panel1, documentViewer);
            //base.OnPreRender(e);
        }

        void xrPictureBox1_BeforePrint(object sender, PrintEventArgs e)
        {
            var picture = (XRPictureBox)sender;
            var report = picture.RootReport;
            //picture.Bookmark = report.GetCurrentColumnValue<string>("EmployeeName");
        }
    }
}