using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;


namespace la_mia_pizzeria_static.Controllers
{
    public class PizzaController : Controller
    {
        public  PizzaContext _dbContext = new PizzaContext();

        public IActionResult Index()
        {
            var pizzas = _dbContext.Pizza?.ToList();
            return View(pizzas);
        }

        public IActionResult Details(int id)
        {
            var pizza = _dbContext.Pizza?.FirstOrDefault(p => p.Id == id);
            return View(pizza);
        }

    }
}
