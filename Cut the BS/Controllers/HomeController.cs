using Cut_the_BS.Models;
using Cut_the_BS.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Cut_the_BS.Controllers
{
    public class HomeController : Controller
    {
        IRecipeDataAccessLayer dal;

        string baseURL = "https://www.themealdb.com/api/json/v1/1/search.php?s=Arrabiata";
        //string baseURL = "https://randomuser.me/api/?results=5";
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
            return View(dal.GetRecipes());
        }

        public async Task<IActionResult> API()
        {
            //Calling API and populating it into a WebAPIConfig
            WebAPIConfig dt = new WebAPIConfig();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("");

                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    dt = JsonConvert.DeserializeObject<WebAPIConfig>(result);
                }
                else
                {
                    Console.WriteLine("API said nah fam");
                }
                ViewData.Model = dt;
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}