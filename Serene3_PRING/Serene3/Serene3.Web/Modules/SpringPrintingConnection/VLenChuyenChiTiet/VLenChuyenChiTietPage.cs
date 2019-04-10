
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VLenChuyenChiTiet"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VLenChuyenChiTietRow))]
    public class VLenChuyenChiTietController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VLenChuyenChiTiet/VLenChuyenChiTietIndex.cshtml");
        }
    }
}