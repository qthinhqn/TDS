
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpCanteen"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpCanteenRow))]
    public class TbEmpCanteenController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpCanteen/TbEmpCanteenIndex.cshtml");
        }
    }
}