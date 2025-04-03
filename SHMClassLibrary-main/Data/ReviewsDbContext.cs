using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHMClassLibrary.Entities;

namespace SHMClassLibrary.Data
{
    public class ReviewsDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = LTIN592795; Initial Catalog = SmartHotelDb; Integrated Security = true; TrustServerCertificate = true; ");
        }

    }
}