using FluentLocalization.WebApi.Enums;

namespace FluentLocalization.WebApi.Persistance.Entites
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Iamge { get; set; }
        public PizzaTypeEnum PizzaType { get; set; }
        public DateTime CreatedOn { get; set; }
        public List<Topping> Toppings { get; set; }

    }
}
