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
    [RoutePrefix("Hrm_tds/TKeNXT"), Route("{action=index}")]
    [PageAuthorize(PermissionKeys.TKeNXTController.View)]
    public class TKeNXTController : Controller
    {
        // GET: TKeNXT
        public ActionResult Index()
        {
            ReportViewerViewModel model = new ReportViewerViewModel();
            string content = Url.Content("~/Modules/Reports/CrystalViewer/TKeNXTList.aspx");
            model.ReportPath = content;
            return View("~/Modules/Reports/TKeNXT/TKeNXTReportViewer.cshtml", model);
        }
    }
}