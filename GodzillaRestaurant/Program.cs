using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GodzillaRestaurant.Data;
using GodzillaRestaurant.Models;
using GodzillaRestaurant.Services;
using GodzillaRestaurant.DataAccessLayer;

var root = Directory.GetCurrentDirectory();
var dotenv = Path.Combine(root, ".env");
DotEnv.Load(dotenv);

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AppDBConnection") ?? throw new InvalidOperationException("Connection string 'AppDBConnection' not found.");

builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Godzilla";
    options.IdleTimeout = new TimeSpan(0, 30, 0);
});

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
builder.Services.AddScoped<IEventService, EventDAL>();
builder.Services.AddScoped<ITestimonialService, TestimonialDAL>();
builder.Services.AddScoped<IGalleryService, GalleryDAL>();
builder.Services.AddScoped<IFoodService, FoodDAL>();
builder.Services.AddScoped<IFoodTypeService, FoodTypeDAL>();
builder.Services.AddScoped<ICartService, CartDAL>();
builder.Services.AddScoped<IOrderService, OrderDAL>();
builder.Services.AddScoped<IPaymentService, PaymentDAL>();
builder.Services.AddScoped<IUserService, UserDAL>();
builder.Services.AddScoped<IBookingService, BookingDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
