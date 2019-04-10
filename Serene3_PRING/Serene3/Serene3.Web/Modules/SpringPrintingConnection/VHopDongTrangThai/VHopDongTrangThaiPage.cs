
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VHopDongTrangThai"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VHopDongTrangThaiRow))]
    public class VHopDongTrangThaiController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VHopDongTrangThai/VHopDongTrangThaiIndex.cshtml");
        }
    }
}