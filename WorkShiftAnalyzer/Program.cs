using Microsoft.EntityFrameworkCore;
using Context;

using DependencyContainer;
using IOC;
using static System.Formats.Asn1.AsnWriter;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MySite")
    ?? throw new InvalidOperationException("Connection string 'MySite' not found.")));


builder.Services.ConfigureDependencies();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DBContext>();
    /// context.Database.Migrate(); // در صورت نیاز، اعمال مهاجرت‌های دیتابیس
    DataSeeder.SeedShiftTypes(context); // مقداردهی اولیه دیتابیس
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
