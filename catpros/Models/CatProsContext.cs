using Microsoft.EntityFrameworkCore;

namespace catpros.Models
{
    public class CatProsContext : DbContext
    {
        public CatProsContext(DbContextOptions<CatProsContext> options) : base(options) {}
        public DbSet<Product> products {get;set;}
        public DbSet<Association> associations {get;set;}
        public DbSet<Category> categories {get;set;}
        
    }
}