using FluentLocalization.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentLocalization
{
    public class LocalizationProfileManager : ILocalizationProfileManager
    {
        public List<ILocalizationProfileBase> Profiles { get; } = new();

        public void AddProfile(ILocalizationProfileBase profile)
        {
            Profiles.Add(profile);
        }

        public List<T> GetProfiles<T>() where T : ILocalizationProfileBase
        {
            return Profiles
                .Where(x => x is T)
                .Select(x => (T)x)
                .ToList();
        }
    }
}
