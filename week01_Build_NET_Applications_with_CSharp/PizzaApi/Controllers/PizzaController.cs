using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;

namespace PizzaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private static readonly List<Pizza> Pizzas =
    [
        new() { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
        new() { Id = 2, Name = "Veggie", IsGlutenFree = true },
        new() { Id = 3, Name = "Spicy Pepperoni", IsGlutenFree = false }
    ];

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll()
    {
        return Pizzas;
    }

    [HttpGet("{id:int}")]
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = Pizzas.FirstOrDefault(pizza => pizza.Id == id);

        if (pizza is null)
        {
            return NotFound();
        }

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        var nextId = Pizzas.Count == 0 ? 1 : Pizzas.Max(existingPizza => existingPizza.Id) + 1;
        pizza.Id = nextId;
        Pizzas.Add(pizza);

        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Pizza updatedPizza)
    {
        var pizza = Pizzas.FirstOrDefault(pizza => pizza.Id == id);

        if (pizza is null)
        {
            return NotFound();
        }

        pizza.Name = updatedPizza.Name;
        pizza.IsGlutenFree = updatedPizza.IsGlutenFree;

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var pizza = Pizzas.FirstOrDefault(pizza => pizza.Id == id);

        if (pizza is null)
        {
            return NotFound();
        }

        Pizzas.Remove(pizza);

        return NoContent();
    }
}
