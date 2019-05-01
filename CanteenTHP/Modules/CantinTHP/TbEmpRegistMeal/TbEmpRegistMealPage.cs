
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpRegistMeal"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpRegistMealRow))]
    public class TbEmpRegistMealController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpRegistMeal/TbEmpRegistMealIndex.cshtml");
        }
    }
}