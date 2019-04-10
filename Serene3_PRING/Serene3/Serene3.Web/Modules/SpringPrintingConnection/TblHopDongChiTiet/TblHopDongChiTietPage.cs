
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblHopDongChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblHopDongChiTietRow))]
    public class TblHopDongChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblHopDongChiTiet/TblHopDongChiTietIndex.cshtml");
        }
    }
}