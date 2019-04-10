
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblHopDongDieuChinh"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblHopDongDieuChinhRow))]
    public class TblHopDongDieuChinhController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblHopDongDieuChinh/TblHopDongDieuChinhIndex.cshtml");
        }
    }
}