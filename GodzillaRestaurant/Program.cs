using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using GodzillaRestaurant.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDBContextConnection") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");

builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/";
    options.LoginPath = "/Login";
});
builder.Services.AddScoped<IChefService, ChefDAL>();
builder.Services.AddScoped<ISpecialService, SpecialDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
