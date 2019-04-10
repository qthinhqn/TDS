
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblKhachHang"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblKhachHangRow))]
    public class TblKhachHangController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblKhachHang/TblKhachHangIndex.cshtml");
        }
    }
}