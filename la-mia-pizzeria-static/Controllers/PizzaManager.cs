﻿using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public static List<Ingredient> GetAllIngredients()
        {
            using PizzaContext _dbContext = new PizzaContext();

            var ingredient = _dbContext.Ingredient?.ToList();
            return ingredient;
        }

        public static List<SelectListItem> CreateIngredients() 
        {
            using PizzaContext _dbContext = new PizzaContext();
            List<SelectListItem> list = new List<SelectListItem>();
            var ingredientFromDb = GetAllIngredients();
            foreach(Ingredient ingredient in ingredientFromDb)
            {
                list.Add(new SelectListItem(ingredient.Name, ingredient.Id.ToString()));
            }
            return list;
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

        public static void InsertPizza(Pizza data, List<string> SelectedIngredient = null)
        {
            using PizzaContext db = new PizzaContext();
            if(SelectedIngredient != null)
            {
                data.Ingredients = new List<Ingredient>();
                foreach(var ingredientId in SelectedIngredient)
                {
                    int id = int.Parse(ingredientId);
                    var ingredient = db.Ingredient.FirstOrDefault(p => p.Id == id);
                    data.Ingredients.Add(ingredient);
                }
            }
            db.Pizza?.Add(data);
            db.SaveChanges();
        }
        public static bool UpdatePizza(int id, string name, string description, float price, int? categoryId)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizza?.Find(id);
            if (pizza == null) return false;
            pizza.Name = name;
            pizza.Description = description;
            pizza.Price = price;
            pizza.CategoryId = categoryId;
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
