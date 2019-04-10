
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblXuongChuyen"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblXuongChuyenRow))]
    public class TblXuongChuyenController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblXuongChuyen/TblXuongChuyenIndex.cshtml");
        }
    }
}