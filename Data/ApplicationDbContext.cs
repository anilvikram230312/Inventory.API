using Inventory.API.Modals;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } 

        public DbSet<Product> Products { get; set; }
    }
}
