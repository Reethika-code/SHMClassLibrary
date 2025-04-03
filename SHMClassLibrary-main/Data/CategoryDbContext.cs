using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using SHMClassLibrary.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHMClassLibrary
{
    public class CategoryDbContext : DbContext
    {
        public DbSet<CategoryModel> Categories { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LTIN589782;User=sa;Password=root;Initial Catalog=SmartHotelDb;Integrated Security=True;TrustServerCertificate=true");
            }
        }
        
    }
}

