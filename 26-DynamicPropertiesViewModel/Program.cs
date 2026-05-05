namespace _26_DynamicPropertiesViewModel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            //app.MapControllerRoute(
            //    "Corporative",
            //    "corporative-sales",
            //    new { controller = "home", action = "corporativesales" }
            //    );

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=home}/{action=index}/{id?}"
                );

            app.Run();
        }
    }
}
