
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefReason4Adjust"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefReason4AdjustRow))]
    public class TbRefReason4AdjustController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefReason4Adjust/TbRefReason4AdjustIndex.cshtml");
        }
    }
}