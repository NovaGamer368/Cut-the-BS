using Cut_the_BS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cut_the_BS.Data;

public class Cut_the_BSContext : IdentityDbContext<IdentityUser>
{
    public Cut_the_BSContext(DbContextOptions<Cut_the_BSContext> options)
        : base(options)
    {
    }

    public DbSet<User> Recipes { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
