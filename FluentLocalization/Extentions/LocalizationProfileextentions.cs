using FluentLocalization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Extentions
{
    public static class LocalizationProfileextentions
    {
        public static LocalizationProfile<TEntity> RegisterEntity

        public static void RegisterProperty<TEntity, TProperty>(this LocalizationProfile<TEntity> localizationProfile, Expression<Func<TEntity, TProperty>> property, string propertyId) where TEntity : class
        {

        }
    }
}
