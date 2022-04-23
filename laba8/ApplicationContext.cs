using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba8
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Curriculum> Curriculums { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Faculty> Facultys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(@"Server=DESKTOP-JJ9RA6U\SQLEXPRESS;Database=relations81labadb;Trusted_Connection=True;");
        }
    }
}
