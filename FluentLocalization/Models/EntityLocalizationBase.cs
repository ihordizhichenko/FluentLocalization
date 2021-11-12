using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Models
{
    public class EntityLocalizationBase
    {
        public string EntityId { get; set; }
        public List<PropertyValue> Properties { get; set; }
    }
}
