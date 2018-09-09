using Asp.AngularCore.git.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp.AngularCore.git.Data
{
    public class LKContext : IdentityDbContext<StoreUser>
    {
        public LKContext(DbContextOptions<LKContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }

}
