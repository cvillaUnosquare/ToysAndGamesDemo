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
    }
}
