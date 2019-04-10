using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Serene3.Models;

namespace Serene3.Controllers
{
    [RoutePrefix("Hrm_tds/RptNhapFE_2"), Route("{action=index}")]
    public class RptNhapFE_2Controller : Controller
    {
        // GET: TKeNXT
        public ActionResult Index()
        {
            ReportViewerViewModel model = new ReportViewerViewModel();
            string content = Url.Content("~/Modules/Reports/CrystalViewer/RptNhapFE2List.aspx");
            model.ReportPath = content;
            return View("~/Modules/Reports/RptNhapFE_2/RptNhapFE_2ReportViewer.cshtml", model);
        }
    }
}