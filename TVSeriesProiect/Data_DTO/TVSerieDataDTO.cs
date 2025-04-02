using Newtonsoft.Json;

namespace TVSeriesProiect.Models
{
    class TVSerieDataDTO
    {
        [JsonProperty("date")]
        public string Date { get; set; } // Stocheaza date din JSON
        [JsonProperty("tvseries")]
        public List<TVSerie> TVSeries { get; set; } //Lista seriale
    }
}
