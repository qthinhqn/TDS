
namespace Canteen.CantinTHP.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("CantinTHP/ZkTblRecord"), Route("{action=index}")]
    [PageAuthorize(typeof(Entities.ZkTblRecordRow))]
    public class ZkTblRecordController : Controller
    {
        public ActionResult Index()
        {
            return View("~/Modules/CantinTHP/ZkTblRecord/ZkTblRecordIndex.cshtml");
        }
    }
}