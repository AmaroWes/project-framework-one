using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Aluroni.Models;

namespace Aluroni.Data
{
    public class AluroniContext : DbContext
    {
        public AluroniContext (DbContextOptions<AluroniContext> options)
            : base(options)
        {
        }

        public DbSet<Aluroni.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Aluroni.Models.Deliveryman> Deliveryman { get; set; } = default!;
        public DbSet<Aluroni.Models.Supplier> Supplier { get; set; } = default!;
        public DbSet<Aluroni.Models.Client> Client { get; set; } = default!;
        public DbSet<Aluroni.Models.Ingredient> Ingredient { get; set; } = default!;
        public DbSet<Aluroni.Models.Stock> Stock { get; set; } = default!;
        public DbSet<Aluroni.Models.Dish> Dish { get; set; } = default!;
        public DbSet<Aluroni.Models.Recipe> Recipe { get; set; } = default!;
        public DbSet<Aluroni.Models.Order> Order { get; set; } = default!;
        public DbSet<Aluroni.Models.Invoce> Invoce { get; set; } = default!;
    }
}
