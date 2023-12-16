using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Data
{
    public class DemoDataContext : DbContext
    {
        public DemoDataContext(DbContextOptions<DemoDataContext> options)
        : base(options) 
        { 
        }

        public DbSet<Models.Product> Products { get; set; }
    }
}
