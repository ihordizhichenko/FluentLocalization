using FluentLocalization.EfCore.Entites;
using Microsoft.EntityFrameworkCore;

namespace FluentLocalization.EfCore
{
    internal class FluentLocalizationDbContext : DbContext
    {
        public DbSet<PropertyLocalization> PropertyLocalizations { get; set; }
    }
}
