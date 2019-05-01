
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbMealCost"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbMealCostRow))]
    public class TbMealCostController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbMealCost/TbMealCostIndex.cshtml");
        }
    }
}