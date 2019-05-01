
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbPreRegistMeal"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbPreRegistMealRow))]
    public class TbPreRegistMealController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbPreRegistMeal/TbPreRegistMealIndex.cshtml");
        }
    }
}