using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GodzillaRestaurant.Data;

public class AppDBContext : IdentityDbContext<IdentityUser>
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
