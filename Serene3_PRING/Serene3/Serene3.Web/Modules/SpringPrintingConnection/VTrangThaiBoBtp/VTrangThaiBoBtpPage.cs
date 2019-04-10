
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VTrangThaiBoBtp"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VTrangThaiBoBtpRow))]
    public class VTrangThaiBoBtpController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VTrangThaiBoBtp/VTrangThaiBoBtpIndex.cshtml");
        }
    }
}