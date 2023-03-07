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
        //Arrabiata
        string baseURL = "https://www.themealdb.com/api/json/v1/1/search.php?s=";
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

        [HttpPost]
        public IActionResult Search(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return View("Communism", dal.GetRecipes());
            }
            return View("Communism", dal.GetRecipes().Where(x => x.Catagory.ToLower().Contains(key.ToLower())));
        }

        [HttpPost]
        public IActionResult Filter(string ingrediants)
        {
            return View("Communism", dal.Filter(ingrediants));
        }

        [HttpPost]
        public IActionResult Edit(Recipe m)
        {
            dal.EditRecipe(m);
            return RedirectToAction("Communism");

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Recipe found = dal.GetRecipe(id);

            if (found == null)
                TempData["Error"] = "Recipe not found";

            return View(found);

        }

        public IActionResult Delete(int? id)
        {

            dal.RemoveRecipe(id);

            return RedirectToAction("Communism");

        }

        public IActionResult Communism()
        {
            return View(dal.GetRecipes());
        }
        //[HttpPost]
        public async Task<IActionResult> API(string searchKey)
        {
            //Calling API and populating it into a WebAPIConfig

            if (string.IsNullOrEmpty(searchKey))
            {
                ViewData.Model = new WebAPIConfig();
                return View();
            } else
            {
                WebAPIConfig dt = new WebAPIConfig();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL + searchKey);
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