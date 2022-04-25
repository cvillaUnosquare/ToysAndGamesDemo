using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToysAndGames.Entities.Entities;

namespace ToysAndGames.Model.Contexts
{
    public class ToysAndGamesDbContext : DbContext
    {
        public ToysAndGamesDbContext(DbContextOptions<ToysAndGamesDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region product seed
            modelBuilder.Entity<Product>().HasData(new Product { 
                Id = 1, 
                Name = "Woody sheriff", 
                Description = "It's toy story cowboy and sheriff", 
                AgeRestriction = 10, 
                Company = "Disney", 
                Price = 22 });

            modelBuilder.Entity<Product>().HasData(new Product { 
                Id = 2, 
                Name = "Jessi the cowboy", 
                Description = "It's a parnership of Woody of Toy Story", 
                AgeRestriction = 10, 
                Company = "Disney", 
                Price = 25 });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Mario's world",
                Description = "It's a game of Mario Bros",
                AgeRestriction = 12,
                Company = "Nintendo",
                Price = 35
            });
            #endregion
        }
    }
}
