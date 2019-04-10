
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VHopDongChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VHopDongChiTietRow))]
    public class VHopDongChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VHopDongChiTiet/VHopDongChiTietIndex.cshtml");
        }
    }
}