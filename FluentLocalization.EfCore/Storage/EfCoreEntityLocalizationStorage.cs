using FluentLocalization.EfCore.Entites;
using FluentLocalization.Interfaces;
using FluentLocalization.Models;
using Microsoft.EntityFrameworkCore;

namespace FluentLocalization.EfCore.Storage
{
    internal class EfCoreEntityLocalizationStorage : IEntityLocalizationStorage
    {
        private readonly FluentLocalizationDbContext _fluentLocalizationDbContext;

        public EfCoreEntityLocalizationStorage(FluentLocalizationDbContext fluentLocalizationDbContext)
        {
            _fluentLocalizationDbContext = fluentLocalizationDbContext;
        }

        public async Task<List<PropertyValue>> GetEntityLocalizationAsync(string entityId, string recordId, string languageCode)
        {
            var query = from pl in _fluentLocalizationDbContext.PropertyLocalizations
                        where pl.EntityId == entityId 
                            && pl.LanguageCode == languageCode
                            && pl.RecordId == recordId
                        select new PropertyValue
                        {
                            PropertyId = pl.PropertyId,
                            Value = pl.Value
                        };

            return await query.ToListAsync() ?? new List<PropertyValue>();
        }

        public async Task<string?> GetPropertyLocalizationAsync(string entityId, string propertyId, string recordId, string languageCode)
        {
            var query = from pl in _fluentLocalizationDbContext.PropertyLocalizations
                        where pl.EntityId == entityId
                            && pl.PropertyId == propertyId
                            && pl.RecordId == recordId
                            && pl.LanguageCode == languageCode
                        select pl.Value;

            return await query.FirstOrDefaultAsync();
        }

        public async Task SetEntityLocalizationAsync(string entityId, List<PropertyValue> properties, string recordId, string languageCode)
        {
            if(properties == null || properties.Count == 0)
            {
                return;
            }

            var propertyIds = properties.Select(x => x.PropertyId).ToList();
            var existedProperties = from pl in _fluentLocalizationDbContext.PropertyLocalizations
                                    where pl.EntityId == entityId
                                        && pl.RecordId == recordId
                                        && propertyIds.Contains(pl.PropertyId)
                                    select pl;

            foreach (var ep in existedProperties)
            {
                ep.Value = properties.FirstOrDefault(x => x.PropertyId == ep.PropertyId).Value;
            }

            var existedProperyIds = existedProperties.Select(x => x.PropertyId).ToList();
            var newProperties = (from pv in properties
                                 where !existedProperyIds.Contains(pv.PropertyId)
                                 select new PropertyLocalization
                                 {
                                     EntityId = entityId,
                                     PropertyId = pv.PropertyId,
                                     RecordId = recordId,
                                     Value = pv.Value,
                                     LanguageCode = languageCode
                                 }).ToList();
            _fluentLocalizationDbContext.PropertyLocalizations.AddRange(newProperties);

            await _fluentLocalizationDbContext.SaveChangesAsync();
        }

        public async Task SetPropertyLocalizationAsync(string entityId, string propertyId, string recordId, string value, string languageCode)
        {
            var query = from pl in _fluentLocalizationDbContext.PropertyLocalizations
                        where pl.EntityId == entityId
                            && pl.PropertyId == propertyId
                            && pl.RecordId == recordId
                            && pl.LanguageCode == languageCode
                        select pl;

            var propertyLocalization = await query.FirstOrDefaultAsync();

            if (propertyLocalization != null)
            {
                propertyLocalization.Value = value;
            }

            await _fluentLocalizationDbContext.SaveChangesAsync();
        }
    }
}
