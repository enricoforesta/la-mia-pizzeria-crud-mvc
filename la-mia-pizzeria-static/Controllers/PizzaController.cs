using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;


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

    }
}
