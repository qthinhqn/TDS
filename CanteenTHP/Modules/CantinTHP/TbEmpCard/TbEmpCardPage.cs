
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/TbEmpCard"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.TbEmpCardRow))]
    public class TbEmpCardController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/TbEmpCard/TbEmpCardIndex.cshtml");
        }
    }
}