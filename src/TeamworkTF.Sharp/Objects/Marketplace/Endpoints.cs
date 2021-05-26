using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TeamworkTF.Sharp
{
    public class EndPoints
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("endpoints")]
        public List<Endpoint> Endpoints { get; set; }
    }

    public class Endpoint
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("version")]
        public int Version { get; set; }

        [JsonPropertyName("key_required")]
        public bool KeyRequired { get; set; }

        [JsonPropertyName("parameters")]
        public List<Parameter> Parameters { get; set; }
    }

    public class Parameter
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("required")]
        public bool Required { get; set; }

        [JsonPropertyName("post_only")]
        public bool PostOnly { get; set; }
    }
}