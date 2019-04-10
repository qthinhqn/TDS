
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblBanThanhPham"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblBanThanhPhamRow))]
    public class TblBanThanhPhamController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblBanThanhPham/TblBanThanhPhamIndex.cshtml");
        }
    }
}