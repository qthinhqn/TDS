
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblRefMau"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblRefMauRow))]
    public class TblRefMauController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblRefMau/TblRefMauIndex.cshtml");
        }
    }
}