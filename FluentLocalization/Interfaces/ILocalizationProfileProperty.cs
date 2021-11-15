using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Interfaces
{
    public interface ILocalizationProfileProperty<TEntity, TProperty> : ILocalizationProfileEntity<TEntity> where TEntity : class
    {

    }
}
