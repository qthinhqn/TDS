
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblNguoiDung"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblNguoiDungRow))]
    public class TblNguoiDungController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblNguoiDung/TblNguoiDungIndex.cshtml");
        }
    }
}