using FluentLocalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Models
{
    public abstract class EntityLocalizationProfile<TEntity, TRecordIdProperty> : IEntityLocalizationProfile<TEntity> where TEntity : class
    {
        private List<PropertyBinding> _properties = new();
        public string EntityName { get; }
        public string RecordId { get; }
        public string EntityId { get; }
        public IReadOnlyCollection<PropertyBinding> Properties
        {
            get
            {
                return _properties.AsReadOnly();
            }
        }

        public EntityLocalizationProfile(Expression<Func<TEntity, TRecordIdProperty>> recordId, string entityId)
        {
            var recordIdExpression = (MemberExpression)recordId.Body;
            RecordId = recordIdExpression.Member.Name;
            EntityName = typeof(TEntity).FullName;
        }

        public void AddProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, string propertyId)
        {
            var propertyExpression = (MemberExpression)property.Body;
            var propertyName = propertyExpression.Member.Name;
            var propertyBinding = new PropertyBinding(propertyName, propertyId);

            if (_properties.Select(x => x.PropertyId).Contains(propertyId))
            {
                throw new Exception($"Property Id duplication: { propertyId }");
            }

            if (_properties.Select(x => x.PropertyName).Contains(propertyName))
            {
                throw new Exception($"Property binding duplication: { propertyName }");
            }

            _properties.Add(propertyBinding);
        }
    }
}
