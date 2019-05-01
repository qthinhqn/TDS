
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbPrePartnerMeal"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbPrePartnerMealRow))]
    public class TbPrePartnerMealController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbPrePartnerMeal/TbPrePartnerMealIndex.cshtml");
        }
    }
}