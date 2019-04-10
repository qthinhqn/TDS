using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Serene3.Models;
using Serenity.Web;
using Serene3.SpringPrintingConnection;
namespace Serene3.Controllers
{
    [RoutePrefix("Hrm_tds/RptXuatFE"), Route("{action=index}")]
    [PageAuthorize(PermissionKeys.RptXuatFEController.View)]
    public class RptXuatFEController : Controller
    {
        // GET: TKeNXT
        public ActionResult Index()
        {
            ReportViewerViewModel model = new ReportViewerViewModel();
            string content = Url.Content("~/Modules/Reports/CrystalViewer/RptXuatFEList.aspx");
            model.ReportPath = content;
            return View("~/Modules/Reports/RptXuatFE/RptXuatFEReportViewer.cshtml", model);
        }
    }
}