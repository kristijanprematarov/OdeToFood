using Microsoft.EntityFrameworkCore;
using OdeToFood.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
