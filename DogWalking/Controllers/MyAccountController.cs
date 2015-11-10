using System.Web.Mvc;
using DogWalking.Models;

namespace DogWalking.Controllers
{
    public class MyAccountController : Controller
    {
        // GET: MyAccount
        public ActionResult Index()
        {
            MyAccountModel model = new MyAccountModel();



            return View(model);
        }
    }
}