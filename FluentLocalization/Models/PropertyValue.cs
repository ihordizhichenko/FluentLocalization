using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Models
{
    public record PropertyValue
    {
        public string PropertyId { get; set; }
        public string Value { get; set; }
    }
}
