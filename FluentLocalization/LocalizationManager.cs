using FluentLocalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization
{
    public class LocalizationManager : ILocalizationManager
    {
        private readonly IEntityLocalizationStorage _entityLocalizationStorage;

        public LocalizationManager(IEntityLocalizationStorage entityLocalizationStorage)
        {
            _entityLocalizationStorage = entityLocalizationStorage;
        }

        public Task AddUpdateLocalizationValueAsync<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property, string value, string language)
        {
            var propertyExpression = (MemberExpression)property.Body;
            string propertyName = propertyExpression.Member.Name;
            string typeName = typeof(TEntity).FullName;


            return Task.CompletedTask;
        }
    }
}
