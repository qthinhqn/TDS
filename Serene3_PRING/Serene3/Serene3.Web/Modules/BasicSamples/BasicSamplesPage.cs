
namespace Serene3.BasicSamples.Pages
{
    using System.Web.Mvc;

    [Authorize, RoutePrefix("BasicSamples"), Route("{action=index}")]
    public partial class BasicSamplesController : Controller
    {
    }
}
