
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblRefNguoiDaiDien"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblRefNguoiDaiDienRow))]
    public class TblRefNguoiDaiDienController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblRefNguoiDaiDien/TblRefNguoiDaiDienIndex.cshtml");
        }
    }
}