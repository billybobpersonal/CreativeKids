using System.Web.Mvc;

namespace DogWalking.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View("gallery");
        }
    }
}