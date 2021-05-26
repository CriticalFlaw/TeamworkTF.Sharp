using Newtonsoft.Json;

namespace TeamworkTF.Sharp
{
    /// <summary>
    /// TODO
    /// </summary>
    public class Sales
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }

    /// <summary>
    /// TODO
    /// </summary>
    public class Dashboard
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}