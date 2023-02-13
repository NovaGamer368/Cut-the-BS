using Microsoft.AspNetCore.Mvc;
using Cut_the_BS.Models;
using Cut_the_BS.Interfaces;


namespace Cut_the_BS.Controllers
{
    public class LoginController : Controller
    {
        IUserDataAccessLayer dal;

        public LoginController(IUserDataAccessLayer indal)
        {
            dal = indal;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewUser()
        {
            return View();
        }
                [HttpPost]
        public IActionResult NewUser(User user)
        { 
                       
            if (ModelState.IsValid)
            {
                dal.AddUser(user);
                TempData["success"] = "New user added!";
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            return RedirectToAction("Home");
        }
    }
}
