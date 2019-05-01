
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpPartnerMeal"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpPartnerMealRow))]
    public class TbEmpPartnerMealController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpPartnerMeal/TbEmpPartnerMealIndex.cshtml");
        }
    }
}