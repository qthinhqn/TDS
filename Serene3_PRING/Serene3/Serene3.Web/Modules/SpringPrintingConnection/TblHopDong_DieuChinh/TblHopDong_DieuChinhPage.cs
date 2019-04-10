
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblHopDong_DieuChinh"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblHopDong_DieuChinhRow))]
    public class TblHopDong_DieuChinhController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblHopDong_DieuChinh/TblHopDong_DieuChinhIndex.cshtml");
        }
    }
}