
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblXuatKhoChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblXuatKhoChiTietRow))]
    public class TblXuatKhoChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblXuatKhoChiTiet/TblXuatKhoChiTietIndex.cshtml");
        }
    }
}