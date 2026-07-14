namespace BlazorPizza.Models;

public sealed record Pizza(
    int Id,
    string Name,
    string Description,
    decimal Price,
    string Emoji);
