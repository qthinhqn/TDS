
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VChiTietBtp_Style_Color"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VChiTietBtp_Style_ColorRow))]
    public class VChiTietBtp_Style_ColorController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VChiTietBtp_Style_Color/VChiTietBtp_Style_ColorIndex.cshtml");
        }
    }
}