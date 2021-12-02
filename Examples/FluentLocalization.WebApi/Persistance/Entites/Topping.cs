namespace FluentLocalization.WebApi.Persistance.Entites
{
    public class Topping
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public List<Pizza> Pizzas { get; set; }
    }
}
