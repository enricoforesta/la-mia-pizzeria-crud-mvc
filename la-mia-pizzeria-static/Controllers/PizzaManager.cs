using la_mia_pizzeria_static.Models;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks.Dataflow;

namespace la_mia_pizzeria_static.Controllers
{
    public static class PizzaManager
    {
        public static List<Pizza> GetAllPizze()
        {
            using PizzaContext _dbContext = new PizzaContext();

            var pizza = _dbContext.Pizza?.ToList();
            return pizza;
        }
        public static Pizza GetIdPizze(int id)
        {
            using PizzaContext _dbContext = new PizzaContext();
            var pizza = _dbContext.Pizza?.FirstOrDefault(p => p.Id == id);
            return pizza;
        }

        public static void InsertPizza(Pizza data)
        {
            using PizzaContext db = new PizzaContext();

            var pizza = new Pizza(data.Name, data.Description, data.PizzaImg, data.Price);
            db.Pizza?.Add(pizza);
            db.SaveChanges();
        }
        public static bool UpdatePizza(int id, string name, string description, float price)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizza?.Find(id);
            if (pizza == null) return false;
            pizza.Name = name;
            pizza.Description = description;
            pizza.Price = price;
            db.SaveChanges();
            return true;
        }

        public static bool DeletePizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizza?.Find(id);
            if (pizza == null) return false;
            db.Pizza.Remove(pizza);
            db.SaveChanges();
            return true;
        }
    }
}
