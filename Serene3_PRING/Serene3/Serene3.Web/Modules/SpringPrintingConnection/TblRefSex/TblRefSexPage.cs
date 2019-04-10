
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblRefSex"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblRefSexRow))]
    public class TblRefSexController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblRefSex/TblRefSexIndex.cshtml");
        }
    }
}