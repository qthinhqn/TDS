
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpCostTemp"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpCostTempRow))]
    public class TbEmpCostTempController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpCostTemp/TbEmpCostTempIndex.cshtml");
        }
    }
}