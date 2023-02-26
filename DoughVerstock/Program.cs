using DoughVerstock.Models;

new Vendor("Suzie's Cafe", "Suzanne Fakename, 1234 Main St, 555-6789");
Order sampleOrder = new Order(1);
sampleOrder.AddGood(new Croissant(12));

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

WebApplication app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
  name: "default",
  pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();