using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        [Key] public int Id { get; set; }

        [Required(ErrorMessage="Il nome è necessario")]
        [StringLength(40, ErrorMessage = "Il nome deve avere max 40 caratteri")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "La descrizione è necessaria")]
        public string? Description { get; set; }

        public string? PizzaImg { get; set; }

        [Required(ErrorMessage = "Il prezzo è necessario")]
        [Range(0, float.MaxValue, ErrorMessage = "Il prezzo deve essere maggiore a zero")]
        public float Price { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public Pizza() { }

        public Pizza(string name, string description, string pizzaImg, float price)
        {
            this.Name = name;
            this.Description = description;
            this.PizzaImg = pizzaImg;
            this.Price = price;
        }

        public string AllCategory()
        {
            if (Category == null) return "Nessuna categoria";
            return Category.Name;
        }
    }
}
