
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblBoBtp"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblBoBtpRow))]
    public class TblBoBtpController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblBoBtp/TblBoBtpIndex.cshtml");
        }
    }
}