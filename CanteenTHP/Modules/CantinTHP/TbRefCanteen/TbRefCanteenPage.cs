
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefCanteen"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefCanteenRow))]
    public class TbRefCanteenController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefCanteen/TbRefCanteenIndex.cshtml");
        }
    }
}