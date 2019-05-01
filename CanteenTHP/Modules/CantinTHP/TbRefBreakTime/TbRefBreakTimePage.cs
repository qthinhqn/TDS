
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefBreakTime"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefBreakTimeRow))]
    public class TbRefBreakTimeController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefBreakTime/TbRefBreakTimeIndex.cshtml");
        }
    }
}