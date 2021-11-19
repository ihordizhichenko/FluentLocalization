using FluentLocalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Models
{
    public class EntityProperties<TEntity> where TEntity : class
    {
        private List<PropertyValue> propertyValues = new();

        private readonly ILocalizationProfileManager _localizationProfileManager;

        public IReadOnlyCollection<PropertyValue> PropertyValues
        {
            get
            {
                return propertyValues.AsReadOnly();
            }
        }

        public EntityProperties(ILocalizationProfileManager localizationProfileManager)
        {
            _localizationProfileManager = localizationProfileManager;
        }

        public void SetValue<TProperty>(Expression<Func<TEntity, TProperty>> property, string value)
        {
            var propertyExpression = (MemberExpression)property.Body;
            string propertyName = propertyExpression.Member.Name;

            var profile = _localizationProfileManager.GetProfile<TEntity>();
            if (profile == null)
            {
                return;
            }

            var propertyId = profile.Properties.FirstOrDefault(x => x.PropertyName == propertyName).PropertyId;
            propertyValues.Add(new PropertyValue { PropertyId = propertyId, Value = value });
        }
    }
}
