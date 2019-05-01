
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpCostCenter"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpCostCenterRow))]
    public class TbEmpCostCenterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpCostCenter/TbEmpCostCenterIndex.cshtml");
        }
    }
}