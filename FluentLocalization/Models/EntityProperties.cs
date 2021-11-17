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
        List<PropertyValue> propertyValues = new ();

        public void AddProperty<TProperty>(Expression<Func<TEntity, TProperty>> property, string value)
        {
            var profile = _localizationProfileManager.GetProfile<TEntity>();
            var propertyId = profile.Properties.FirstOrDefault(x => x.PropertyName == propertyName).PropertyId;
        }
    }
}
