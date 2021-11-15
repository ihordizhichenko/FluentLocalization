namespace FluentLocalization.EfCore.Entites
{
    internal class PropertyLocalization
    {
        public int Id { get; set; }
        public string EntityId { get; set; }
        public string RecordId { get; set; }
        public string PropertyId { get; set; }
        public string? Value { get; set; }
        public string LanguageCode { get; set; }
    }
}
