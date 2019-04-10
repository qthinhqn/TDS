
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblXuongChuyenIn_ChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblXuongChuyenIn_ChiTietRow))]
    public class TblXuongChuyenIn_ChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblXuongChuyenIn_ChiTiet/TblXuongChuyenIn_ChiTietIndex.cshtml");
        }
    }
}