using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp1.Areas.Identity.Models;
using System.Linq;

namespace WebApp1.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ApplicationUser> ApplicationUser { get; set; } = default!;
    public DbSet<Computation> Computation { get; set; }
    public DbSet<Revenue> Revenue { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computation>().ToTable("Computation").HasMany( c => c.Revenues).WithOne(e => e.Computation);
            modelBuilder.Entity<Revenue>().ToTable("Revenue").Ignore( x=> x.Computation);
            base.OnModelCreating(modelBuilder);
        }
    
}
