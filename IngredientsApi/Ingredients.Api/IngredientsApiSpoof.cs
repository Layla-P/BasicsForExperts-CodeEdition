using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Ingredients.Api;

public class Ingredient
{
    [JsonInclude]
    public int id { get; set; }
    [JsonInclude]
    public string name { get; set; }
    [JsonInclude]
    public string type { get; set; }
}

public static class IngredientsApiSpoof
{
    public static List<Ingredient> GetIngredients()
    {
        return new List<Ingredient>
        {
            new Ingredient
            {
                id = 1,
                name = "Vanilla icecream",
                type = "Standard"
            },
            new Ingredient
            {
                id = 2,
                name = "Strawberry icecream",
                type = "Standard"
            },
            new Ingredient
            {
                id = 3,
                name = "Chocolate icecream",
                type = "Standard"
            },
            new Ingredient
            {
                id = 4,
                name = "Pistacio icecream",
                type = "Standard"
            },
            new Ingredient
            {
                id = 5,
                name = "Chocolate sauce",
                type = "Standard"
            },
            new Ingredient
            {
                id = 6,
                name = "Syrup",
                type = "Standard"
            },
            new Ingredient
            {
                id = 7,
                name = "Fresh bananas",
                type = "LowFat"
            },
            new Ingredient
            {
                id = 8,
                name = "Fresh strawberries",
                type = "LowFat"
            },
            new Ingredient
            {
                id = 9,
                name = "Fresh raspberries",
                type = "LowFat"
            },
            new Ingredient
            {
                id = 10,
                name = "Greek Yoghurt",
                type = "LowFat"
            },
            new Ingredient
            {
                id = 11,
                name = "Cheddar cheese",
                type = "Savoury"
            },
            new Ingredient
            {
                id = 12,
                name = "Vegan cheese",
                type = "Savoury"
            },
            new Ingredient
            {
                id = 13,
                name = "Bacon",
                type = "Savoury"
            },
            new Ingredient
            {
                id = 14,
                name = "Fried chicken",
                type = "Savoury"
            },
            new Ingredient
            {
                id = 15,
                name = "Chipotle maple syrup",
                type = "Savoury"
            }
        };
    }

}