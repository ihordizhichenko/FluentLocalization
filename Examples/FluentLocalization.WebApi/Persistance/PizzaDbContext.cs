using FluentLocalization.WebApi.Persistance.Configurations;
using FluentLocalization.WebApi.Persistance.Entites;
using Microsoft.EntityFrameworkCore;

namespace FluentLocalization.WebApi.Persistance
{
    public class PizzaDbContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PizzaTypeConfiguration());

            base.OnModelCreating(builder); 
        }
    }
}
