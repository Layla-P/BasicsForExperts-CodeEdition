using BasicsForExperts.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace BasicsForExperts.Web.DTOs
{

    public class ToppingDto
    {

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("type")]
        [JsonConverter(typeof(EnumConvertor<WaffleTypeEnum>))]
        public WaffleTypeEnum Type { get; init; }
    }
}
