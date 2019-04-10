
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblHopDong_ChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblHopDong_ChiTietRow))]
    public class TblHopDong_ChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblHopDong_ChiTiet/TblHopDong_ChiTietIndex.cshtml");
        }
    }
}