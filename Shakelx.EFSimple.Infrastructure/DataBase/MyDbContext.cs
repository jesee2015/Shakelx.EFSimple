using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shakelx.EFSimple.Core.Entities;
using Shakelx.EFSimple.Infrastructure.DataBase.EntityConfigurations;

namespace Shakelx.EFSimple.Infrastructure.DataBase
{
    public class MyDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, int>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
    }
}
