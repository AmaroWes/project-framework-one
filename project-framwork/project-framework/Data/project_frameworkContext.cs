using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_framework.Models;

namespace project_framework.Data
{
    public class project_frameworkContext : DbContext
    {
        public project_frameworkContext (DbContextOptions<project_frameworkContext> options)
            : base(options)
        {
        }

        public DbSet<project_framework.Models.Employees> Employees { get; set; } = default!;
        public DbSet<project_framework.Models.Deliveryman> Deliveryman { get; set; } = default!;
        public DbSet<project_framework.Models.Supplier> Supplier { get; set; } = default!;
        public DbSet<project_framework.Models.Client> Client { get; set; } = default!;
        public DbSet<project_framework.Models.Ingredient> Ingredient { get; set; } = default!;
        public DbSet<project_framework.Models.Stock> Stock { get; set; } = default!;
        public DbSet<project_framework.Models.Dish> Dish { get; set; } = default!;
        public DbSet<project_framework.Models.Order> Order { get; set; } = default!;
        public DbSet<project_framework.Models.Invoce> Invoce { get; set; } = default!;
    }
}
