using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization.Interfaces
{
    public interface ILocalizationProfileManager
    {
        void AddProfile(ILocalizationProfileBase profile);
    }
}
