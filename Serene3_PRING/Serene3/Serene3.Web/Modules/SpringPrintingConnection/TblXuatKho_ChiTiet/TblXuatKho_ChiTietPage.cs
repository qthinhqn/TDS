
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblXuatKho_ChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblXuatKho_ChiTietRow))]
    public class TblXuatKho_ChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblXuatKho_ChiTiet/TblXuatKho_ChiTietIndex.cshtml");
        }
    }
}