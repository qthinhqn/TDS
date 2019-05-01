
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefMenu"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefMenuRow))]
    public class TbRefMenuController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefMenu/TbRefMenuIndex.cshtml");
        }
    }
}