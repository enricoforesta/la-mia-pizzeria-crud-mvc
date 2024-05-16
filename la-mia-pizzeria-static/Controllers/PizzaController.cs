using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {

        public IActionResult Index()
        {

            return View(PizzaManager.GetAllPizze());
        }

        public IActionResult Details(int id)
        {

            return View(PizzaManager.GetIdPizze(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            using PizzaContext db = new PizzaContext();

            var pizza = new Pizza(data.Name, data.Description, data.PizzaImg, data.Price);
            db.Pizza.Add(pizza);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
