using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
       [Key] public int Id { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? PizzaImg { get; set; }

        public float Price { get; set; }


        public Pizza() { }

        public Pizza(string name, string description, string pizzaImg, float price)
        {
            this.Name = name;
            this.Description = description;
            this.PizzaImg = pizzaImg;
            this.Price = price;
        }
    }


}
