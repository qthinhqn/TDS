
namespace Canteen.CantinTHP.Pages
{
    using Canteen;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/Reports"), Route("{action=index}")]
    //[PageAuthorize(PermissionKeys.)]
    public class ReportsController : Controller
    {
        public ActionResult Index()
        {
            return View(MVC.Views.Common.Reporting.ReportPage, 
                new ReportRepository().GetReportTree("CantinTHP"));
        }
    }
}
