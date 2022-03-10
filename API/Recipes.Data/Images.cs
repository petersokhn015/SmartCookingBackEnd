using Newtonsoft.Json;

namespace Recipes.Data
{
    public class Images
    {
        [JsonProperty("THUMBNAIL")]
        public Image Thumbnail { get; set; }

        [JsonProperty("SMALL")]
        public Image Small { get; set; }

        [JsonProperty("REGULAR")]
        public Image Regular { get; set; }

        [JsonProperty("LARGE")]
        public Image Large { get; set; }
    }
}
