using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastracture.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration configuration;

        public DataContext(DbContextOptions options, IConfiguration configuration):base(options) {

            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product { Id=1, Name = "چادر مسافرتی", CreationDate= new DateTime(2022,02,01), Price=2500000 },
                new Product { Id=2, Name = "اتو ", CreationDate= new DateTime(2022,03,01), Price=3500000 },
                new Product { Id=3, Name = " پتو", CreationDate= new DateTime(2022,04,01), Price=50000 },
                new Product { Id=4, Name = " تلویزیون", CreationDate= new DateTime(2022,05,01), Price=650000 },
                new Product { Id=5, Name = " مبل", CreationDate= new DateTime(2022,06,01), Price=45550000 },
                new Product { Id=6, Name = " مبل", CreationDate= new DateTime(2022,06,01), Price=45550000 },
            });
        }

        public DbSet<Product> Products { get; set; }
    }
}
