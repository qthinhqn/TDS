
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblLenChuyenIn_ChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblLenChuyenIn_ChiTietRow))]
    public class TblLenChuyenIn_ChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblLenChuyenIn_ChiTiet/TblLenChuyenIn_ChiTietIndex.cshtml");
        }
    }
}