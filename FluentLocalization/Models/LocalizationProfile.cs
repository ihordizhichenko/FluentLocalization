using FluentLocalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Models
{
    public class LocalizationProfile<TEntity> where TEntity : class
    {
        public List<ILocalizationProfileBase<TEntity>> MyProperty { get; set; }
    }
}
