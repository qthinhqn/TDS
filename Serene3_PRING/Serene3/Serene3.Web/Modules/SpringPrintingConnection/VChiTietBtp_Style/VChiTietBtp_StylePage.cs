
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VChiTietBtp_Style"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VChiTietBtp_StyleRow))]
    public class VChiTietBtp_StyleController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VChiTietBtp_Style/VChiTietBtp_StyleIndex.cshtml");
        }
    }
}