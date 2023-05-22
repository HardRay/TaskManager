using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity;

namespace DAL
{
    public class DefaultDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DefaultDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=TeamBuilding;Username=postgres;Password=12345");
        }
    }
}
