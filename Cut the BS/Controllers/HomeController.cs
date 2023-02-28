using Cut_the_BS.Models;
using Cut_the_BS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Cut_the_BS.Controllers
{
    public class HomeController : Controller
    {
        IRecipeDataAccessLayer dal;

        public HomeController(IRecipeDataAccessLayer indal)
        {
            dal = indal;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet] 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] 
        public IActionResult Create(Recipe r)
        {
          
            if (ModelState.IsValid)
            {
                dal.AddRecipe(r);
                TempData["success"] = "Recipe added";
                return RedirectToAction("Communism");
            }
            return View();
        }
        public IActionResult Communism()
        {
            return View();
        }

        public IActionResult API()
        {
            return View();
        }

    }
}