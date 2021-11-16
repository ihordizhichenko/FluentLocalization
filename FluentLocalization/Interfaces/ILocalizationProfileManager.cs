namespace FluentLocalization.Interfaces
{
    public interface ILocalizationProfileManager
    {
        IReadOnlyCollection<ILocalizationProfileBase> Profiles { get; }
        void AddProfile(ILocalizationProfileBase profile);
        IEntityLocalizationProfile<T>? GetProfile<T>() where T : class;
    }
}
