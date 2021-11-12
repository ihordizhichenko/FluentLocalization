using FluentLocalization.Models;

namespace FluentLocalization.Interfaces
{
    public interface IEntityLocalizationStorage
    {
        Task<string?> GetPropertyLocalizationAsync(string entityId, string propertyId, string recordId, string languageCode);
        Task<List<PropertyValue>> GetEntityLocalizationAsync(string entityId, string recordId, string languageCode);
        Task SetPropertyLocalizationAsync(string entityId, string propertyId, string recordId, string value, string languageCode);
        Task SetEntityLocalizationAsync(string entityId, List<PropertyValue> properties, string recordId, string languageCode);
    }
}
