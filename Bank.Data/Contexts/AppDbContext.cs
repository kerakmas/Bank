using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string query = "Server=(localdb)\\MSSQLLocalDB; Database=BaknDb; Trusted_Connection=true";
            optionsBuilder.UseSqlServer(query);
        }
        public DbSet<User> Users { get; set; } 
    }
}
