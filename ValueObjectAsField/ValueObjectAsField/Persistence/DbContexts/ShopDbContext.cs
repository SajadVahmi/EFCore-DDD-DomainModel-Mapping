using Framework.Tools.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjectAsField.Domain.Models;
using ValueObjectAsField.Persistence.Mappings;
using static ValueObjectAsField.Persistence.Mappings.OrderMapping;

namespace ValueObjectAsField.Persistence.DbContexts
{
    public class ShopDbContext:DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Shop;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderMapping).Assembly);

            base.OnModelCreating(modelBuilder);

            modelBuilder.UseValueConverter(new OrderIdValueConverter());
           
        }
    }
}
