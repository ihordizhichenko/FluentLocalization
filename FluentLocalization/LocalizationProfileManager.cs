using FluentLocalization.Interfaces;

namespace FluentLocalization
{
    public class LocalizationProfileManager : ILocalizationProfileManager
    {
        private List<ILocalizationProfileBase> _profiles = new();

        public IReadOnlyCollection<ILocalizationProfileBase> Profiles 
        { 
            get
            {
                return _profiles.AsReadOnly();
            }
        }

        public void AddProfile(ILocalizationProfileBase profile)
        {
            _profiles.Add(profile);
        }

        public IEntityLocalizationProfile<T>? GetProfile<T>() where T : class
        {
            return Profiles
                .Where(x => x is IEntityLocalizationProfile<T>)
                .Select(x => (IEntityLocalizationProfile<T>)x)
                .FirstOrDefault();
        }
    }
}
