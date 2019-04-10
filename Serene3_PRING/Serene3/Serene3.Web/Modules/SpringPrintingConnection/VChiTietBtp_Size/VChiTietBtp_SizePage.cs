
namespace Serene3.SpringPrintingConnection.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("SpringPrintingConnection/VChiTietBtp_Size"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.VChiTietBtp_SizeRow))]
    public class VChiTietBtp_SizeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/SpringPrintingConnection/VChiTietBtp_Size/VChiTietBtp_SizeIndex.cshtml");
        }
    }
}