
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblHopDong"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblHopDongRow))]
    public class TblHopDongController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblHopDong/TblHopDongIndex.cshtml");
        }
    }
}