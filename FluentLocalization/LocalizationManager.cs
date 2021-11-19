using FluentLocalization.Interfaces;
using FluentLocalization.Models;
using System.Linq.Expressions;

namespace FluentLocalization
{
    public class LocalizationManager : ILocalizationManager
    {
        private readonly IEntityLocalizationStorage _entityLocalizationStorage;
        private readonly ILocalizationProfileManager _localizationProfileManager;

        public LocalizationManager(
            IEntityLocalizationStorage entityLocalizationStorage,
            ILocalizationProfileManager localizationProfileManager)
        {
            _entityLocalizationStorage = entityLocalizationStorage;
            _localizationProfileManager = localizationProfileManager;
        }

        public Task<string> GetLocalization(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetEntityLocalization<T>(T entity, string language) where T : class
        {
            var profile = _localizationProfileManager.GetProfile<T>();
            if(profile == null)
            {
                return null;
            }

            var entityType = entity.GetType();

            var recordIdValue = entityType.GetProperty(profile.RecordId).GetValue(entity, null).ToString();
            var localizedProperties = await _entityLocalizationStorage.GetEntityLocalizationAsync(profile.EntityId, recordIdValue, language);

            foreach(var localizedProperty in localizedProperties)
            {
                var propertyName = profile.Properties.FirstOrDefault(x => x.PropertyId == localizedProperty.PropertyId).PropertyName;
                entityType.GetProperty(propertyName).SetValue(entity, localizedProperty, null);
            }

            return entity;
        }

        public async Task SetEntityLocalization<TEntity>(TEntity entity, EntityProperties<TEntity> entityPproperties, string language) where TEntity : class
        {
            var profile = _localizationProfileManager.GetProfile<TEntity>();
            var entityType = entity.GetType();
            var recordIdValue = entityType.GetProperty(profile.RecordId).GetValue(entity, null).ToString();

            await _entityLocalizationStorage.SetEntityLocalizationAsync(profile.EntityId, entityPproperties.PropertyValues.ToList(), recordIdValue, language);
        }

        public async Task SetPropertyLocalization<TEntity, TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> property, string value, string language) where TEntity : class
        {
            var propertyExpression = (MemberExpression)property.Body;
            string propertyName = propertyExpression.Member.Name;

            var profile = _localizationProfileManager.GetProfile<TEntity>();
            var propertyId = profile.Properties.FirstOrDefault(x => x.PropertyName == propertyName).PropertyId;
            var entityType = entity.GetType();
            var recordIdValue = entityType.GetProperty(profile.RecordId).GetValue(entity, null).ToString();

            await _entityLocalizationStorage.SetPropertyLocalizationAsync(profile.EntityId, propertyId, recordIdValue, value, language);
        }
    }
}
