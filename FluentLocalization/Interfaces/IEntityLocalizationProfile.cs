using FluentLocalization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Interfaces
{
    public interface IEntityLocalizationProfile<TEntity> : ILocalizationProfileBase where TEntity : class
    {
        public string EntityName { get; }
        public string RecordId { get; }
        public string EntityId { get; }
        public IReadOnlyCollection<PropertyBinding> Properties { get; }
    }
}
