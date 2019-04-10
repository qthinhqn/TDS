
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblXuongChuyenInChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblXuongChuyenInChiTietRow))]
    public class TblXuongChuyenInChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblXuongChuyenInChiTiet/TblXuongChuyenInChiTietIndex.cshtml");
        }
    }
}