﻿using la_mia_pizzeria_static.Models;
using System.Collections.Generic;

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
    }
}