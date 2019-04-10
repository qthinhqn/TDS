
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/GroupingIn"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VTrangThaiBoBtpRow))]
    public class GroupingInPageController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/GroupingIn/GroupingInIndex.cshtml");
        }
    }
}