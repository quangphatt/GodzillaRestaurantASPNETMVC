using GodzillaRestaurant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.Data;

public class AppDBContext : IdentityDbContext<AppUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public virtual DbSet<Chef> Chef { get; set; }
    public virtual DbSet<Special> Special { get; set; }
    public virtual DbSet<Event> Event { get; set; }
    public virtual DbSet<Testimonial> Testimonial { get; set; }
    public virtual DbSet<GalleryItem> GalleryItem { get; set; }
    public virtual DbSet<Food> Food { get; set; }
    public virtual DbSet<FoodType> FoodType { get; set; }
    public virtual DbSet<Order> Order { get; set; }
    public virtual DbSet<OrderItem> OrderItem { get; set; }
    public virtual DbSet<Payment> Payment { get; set; }
}
