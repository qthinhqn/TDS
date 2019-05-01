
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpCompany"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpCompanyRow))]
    public class TbEmpCompanyController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpCompany/TbEmpCompanyIndex.cshtml");
        }
    }
}