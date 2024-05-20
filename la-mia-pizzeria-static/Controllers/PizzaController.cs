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
            var Pizza = PizzaManager.GetIdPizze(id,true);
            if (Pizza == null) return View("errore");
            return View(Pizza);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PizzaFormModel model = new PizzaFormModel(new Pizza(), PizzaManager.GetAllCategory());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PizzaFormModel data)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", data);
            }

            PizzaManager.InsertPizza(data.Pizza);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var pizzaEdit = PizzaManager.GetIdPizze(id);
            if (pizzaEdit == null) return NotFound();
            PizzaFormModel model = new PizzaFormModel(pizzaEdit, PizzaManager.GetAllCategory());

            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id,PizzaFormModel data)
        {
            if (!ModelState.IsValid) return View("Update", data);
            if(!PizzaManager.UpdatePizza(id, data.Pizza?.Name, data.Pizza?.Description, data.Pizza.Price, data.Pizza?.CategoryId)) return NotFound();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (!PizzaManager.DeletePizza(id)) return NotFound();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
