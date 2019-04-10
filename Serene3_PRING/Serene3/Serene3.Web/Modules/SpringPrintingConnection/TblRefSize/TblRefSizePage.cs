
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblRefSize"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblRefSizeRow))]
    public class TblRefSizeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblRefSize/TblRefSizeIndex.cshtml");
        }
    }
}