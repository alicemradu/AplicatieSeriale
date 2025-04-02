using Newtonsoft.Json;
using System.Net;
using TVSeriesProiect.Models;

namespace TVSeriesProiect.Services
{
    public class TopTVSeriesService
    {
        public async Task<List<TVSerie>> DownloadAndParseJsonTVSeriesAsync()
        {
            //JSON cu date
            string url = "https://raw.githubusercontent.com/alicemradu/DateAplicatieSeriale/refs/heads/main/dateSeriale.json";
            var tvSerieList = new List<TVSerie>();

            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(url);

                var dto = JsonConvert.DeserializeObject<TVSerieDataDTO>(json);

                tvSerieList = dto.TVSeries;
            }
            return tvSerieList;
        }
    }
}
