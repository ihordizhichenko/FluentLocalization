using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Models
{
    public class PropertyLocalizationModel
    {
        public string EntityId { get; set; }
        public string PropertyId { get; set; }
        public string RecordId { get; set; }
        public string Value { get; set; }
        public string LanguageCode { get; set; }
    }
}
