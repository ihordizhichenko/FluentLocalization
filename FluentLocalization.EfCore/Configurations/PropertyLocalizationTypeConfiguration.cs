using FluentLocalization.EfCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentLocalization.EfCore.Configurations
{
    internal class PropertyLocalizationTypeConfiguration : IEntityTypeConfiguration<PropertyLocalization>
    {
        public void Configure(EntityTypeBuilder<PropertyLocalization> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EntityId)
                .IsRequired();
            builder.Property(x => x.PropertyId)
                .IsRequired();
            builder.Property(x => x.LanguageCode)
                .IsRequired();
        }
    }
}
