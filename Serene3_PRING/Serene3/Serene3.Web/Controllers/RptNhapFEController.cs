using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Serene3.Models;

namespace Serene3.Controllers
{
    [RoutePrefix("Hrm_tds/RptNhapFE"), Route("{action=index}")]
    public class RptNhapFEController : Controller
    {
        // GET: TKeNXT
        public ActionResult Index()
        {
            ReportViewerViewModel model = new ReportViewerViewModel();
            string content = Url.Content("~/Modules/Reports/CrystalViewer/RptNhapFEList.aspx");
            model.ReportPath = content;
            return View("~/Modules/Reports/RptNhapFE/RptNhapFEReportViewer.cshtml", model);
        }
    }
}