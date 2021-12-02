using FluentLocalization.WebApi.Persistance.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentLocalization.WebApi.Persistance.Configurations
{
    public class PizzaTypeConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Toppings)
                .WithMany(x => x.Pizzas);
        }
    }
}
