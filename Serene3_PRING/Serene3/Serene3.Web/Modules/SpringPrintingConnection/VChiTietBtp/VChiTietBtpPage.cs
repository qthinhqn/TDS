
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VChiTietBtp"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VChiTietBtpRow))]
    public class VChiTietBtpController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VChiTietBtp/VChiTietBtpIndex.cshtml");
        }
    }
}