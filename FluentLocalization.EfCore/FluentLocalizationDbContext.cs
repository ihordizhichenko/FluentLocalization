using FluentLocalization.EfCore.Configurations;
using FluentLocalization.EfCore.Entites;
using Microsoft.EntityFrameworkCore;

namespace FluentLocalization.EfCore
{
    internal class FluentLocalizationDbContext : DbContext
    {
        public DbSet<PropertyLocalization> PropertyLocalizations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PropertyLocalizationTypeConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
