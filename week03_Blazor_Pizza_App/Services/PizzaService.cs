using BlazorPizza.Models;

namespace BlazorPizza.Services;

public sealed class PizzaService
{
    private static readonly IReadOnlyList<Pizza> Pizzas = new List<Pizza>
    {
        new(1, "Margherita", "Tomato sauce, mozzarella, and fresh basil.", 8.99m, "🍅"),
        new(2, "Pepperoni", "Mozzarella and generous slices of pepperoni.", 10.99m, "🍕"),
        new(3, "Veggie Garden", "Peppers, mushrooms, red onion, sweetcorn, and olives.", 9.75m, "🫑"),
        new(4, "BBQ Chicken", "Chicken, red onion, mozzarella, and smoky BBQ sauce.", 11.50m, "🍗"),
        new(5, "Hawaiian", "Ham, pineapple, mozzarella, and tomato sauce.", 10.25m, "🍍"),
        new(6, "Meat Feast", "Pepperoni, sausage, ham, beef, and extra cheese.", 12.99m, "🥩")
    };

    public IReadOnlyList<Pizza> GetPizzas() => Pizzas;

    public Pizza? GetPizza(int id) => Pizzas.FirstOrDefault(pizza => pizza.Id == id);
}
