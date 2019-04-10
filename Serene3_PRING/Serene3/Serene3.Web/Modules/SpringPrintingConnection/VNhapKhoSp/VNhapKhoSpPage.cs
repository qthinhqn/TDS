
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VNhapKhoSp"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VNhapKhoSpRow))]
    public class VNhapKhoSpController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VNhapKhoSp/VNhapKhoSpIndex.cshtml");
        }
    }
}