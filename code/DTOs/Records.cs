using System.Text.Json.Serialization;

namespace BasicsForExperts.Web.DTOs
{


    public record struct WaffleOrder
    {
        [JsonPropertyName("user-id")]
        public int UserId { get; init; }

        [JsonPropertyName("base")]
        public string Base { get; init; }

        [JsonPropertyName("toppings")]
        public List<ToppingDto> Toppings { get; init; }
    }

}
