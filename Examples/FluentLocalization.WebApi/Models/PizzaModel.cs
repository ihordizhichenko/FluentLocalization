using FluentLocalization.WebApi.Enums;
using FluentLocalization.WebApi.Persistance.Entites;

namespace FluentLocalization.WebApi.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Iamge { get; set; }
        public string PizzaType { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<ToppingModel> Toppings { get; set; }
    }
}
