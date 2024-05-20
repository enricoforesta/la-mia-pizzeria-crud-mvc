using la_mia_pizzeria_static.Models;
using Microsoft.EntityFrameworkCore;
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
        public static List<Category> GetAllCategory()
        {
            using PizzaContext _dbContext = new PizzaContext();

            var category = _dbContext.Category?.ToList();
            return category;
        }
        public static Pizza GetIdPizze(int id, bool includeReferences = true)
        {
            using PizzaContext _dbContext = new PizzaContext();
            if(includeReferences)
            {
                var pizzaInclude = _dbContext.Pizza?.Where(p => p.Id == id).Include(p => p.Category).FirstOrDefault();
                return pizzaInclude;
            }
            var pizza = _dbContext.Pizza?.FirstOrDefault(p => p.Id == id);
            return pizza;
        }

        public static void InsertPizza(Pizza data)
        {
            using PizzaContext db = new PizzaContext();

            db.Pizza?.Add(data);
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
