using System.Globalization;

namespace la_mia_pizzeria_static
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Pizza}/{action=Index}/{id?}");



            app.Run();
        }
    }
}

//        var pizza = new List<Pizza>
// {
//    new Pizza("Pizza Capricciosa", "Molto Buona", "~/img/PizzaCapricciosa.jpg", 10.00M),
//    new Pizza("Pizza Margherita", "Molto Buona", "~/img/PizzaMargherita.jpg", 8.50M),
//    new Pizza("Pizza Fritta", "Molto Buona", "~/img/PizzaFritta.jpeg", 25.98M),
//    new Pizza("Pizza Marinara", "Molto Buona", "~/img/PizzaMarinara.jpg", 9.50M),
//    new Pizza("Pizza Napoletana", "Molto Buona", "~/img/PizzaNapoletana.jpg", 14.00M),
//    new Pizza("Pizza Patate e Salsiccia", "Molto Buona", "~/img/PizzaPatateSalsiccia.jpg", 12.50M),
//};
//        using PizzaContext db = new PizzaContext();


//        db.Pizza.AddRange(pizza);
//        db.SaveChanges();



            // Per 
            //var defaultCulture = new CultureInfo("en-US");
            //var localizationOptions = new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture),
            //    SupportedCultures = new List<CultureInfo>
            //    {
            //        defaultCulture,
            //    },
            //    SupportedUICultures = new List<CultureInfo>
            //    {
            //        defaultCulture,
            //    }
            //};

            //app.UseRequestLocalization(localizationOptions);