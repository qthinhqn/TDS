
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbRefCompany"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbRefCompanyRow))]
    public class TbRefCompanyController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbRefCompany/TbRefCompanyIndex.cshtml");
        }
    }
}