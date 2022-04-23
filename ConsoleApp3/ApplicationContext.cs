using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class ApplicationContext : DbContext
 {
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.

           UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb7;Trusted_Connection=True;");
        }
    }
}
