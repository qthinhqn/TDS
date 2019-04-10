
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblLenChuyenInChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblLenChuyenInChiTietRow))]
    public class TblLenChuyenInChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblLenChuyenInChiTiet/TblLenChuyenInChiTietIndex.cshtml");
        }
    }
}