
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefCostCenter"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefCostCenterRow))]
    public class TbRefCostCenterController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefCostCenter/TbRefCostCenterIndex.cshtml");
        }
    }
}