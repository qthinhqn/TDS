
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/TblFeCardInfo"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TblFeCardInfoRow))]
    public class TblFeCardInfoController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/TblFeCardInfo/TblFeCardInfoIndex.cshtml");
        }
    }
}