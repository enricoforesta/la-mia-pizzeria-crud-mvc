using Microsoft.AspNetCore.Mvc.Rendering;

namespace la_mia_pizzeria_static.Models
{
    public class PizzaFormModel
    {
        public Pizza? Pizza { get; set; }
        public List<Category>? Categories { get; set; }

        public List<SelectListItem>? Ingredients { get; set; }
        public List<string> SelectedIngredients { get; set; }
        public PizzaFormModel() 
        {
            SelectedIngredients = new List<string>();
        }

        public PizzaFormModel(Pizza pizza, List<Category> category, List<SelectListItem> selectedIngredients) 
        {
            this.Pizza = pizza;
            this.Categories = category;
            this.Ingredients = selectedIngredients;
            this.SelectedIngredients = new List<string>();
        }

    }
}
