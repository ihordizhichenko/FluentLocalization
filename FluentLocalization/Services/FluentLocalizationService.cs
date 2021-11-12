using FluentLocalization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Services
{
    public class FluentLocalizationService
    {
        public Dictionary<Type, EntityLocalizationBase> LocalizationTypes { get; set; }
    }
}
