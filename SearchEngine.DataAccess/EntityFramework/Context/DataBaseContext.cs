using Microsoft.EntityFrameworkCore;
using SearchEngine.Common.Contants;
using SearchEngine.Entities.Dto;

namespace SearchEngine.DataAccess.EntityFramework.Context
{
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        public DbSet<Product> Product { get; set; }
        public DbSet<ProductTypePriority> ProductTypePriority { get; set; }
    }
}
