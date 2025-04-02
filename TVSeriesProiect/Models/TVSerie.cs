using Newtonsoft.Json;
using SQLite;

namespace TVSeriesProiect.Models
{

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [Table("tvserie")]
    public class TVSerie
    {
        //id
        [Column("id"), PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //title
        [JsonProperty("Title")]
        [Column("title")]
        public string Title { get; set; }

        //released
        [JsonProperty("Released")]
        [Column("released")]
        public string Released { get; set; }

        //runtime
        [JsonProperty("Runtime")]
        [Column("time")]
        public string Time { get; set; }

        //genre
        [JsonProperty("Genre")]
        [Column("genre")]
        public string Genre { get; set; }

        //actors
        [JsonProperty("Actors")]
        [Column("actors")]
        public string Actors { get; set; }

        //plot
        [JsonProperty("Plot")]
        [Column("plot")]
        public string Plot { get; set; }

        //language
        [JsonProperty("Language")]
        [Column("language")]
        public string Language { get; set; }

        //poster
        [JsonProperty("Poster")]
        [Column("poster")]
        public string Poster { get; set; }

        //rating
        [JsonProperty("imdbRating")]
        [Column("rating")]
        public string Rating { get; set; }

        //imdb votes
        [JsonProperty("imdbVotes")]
        [Column("imdbVotes")]
        public string imdbVotes { get; set; }

        //constructor
        public TVSerie(string title, string released, string time, string genre, string actors, string plot, string language, string poster, string rating, string imdbVotes)
        {
            Title = title;
            Released = released;
            Time = time;
            Genre = genre;
            Actors = actors;
            Plot = plot;
            Language = language;
            Poster = poster;
            Rating = rating;
            this.imdbVotes = imdbVotes;

        }

        //default constructor
        public TVSerie() { }
    }
}
