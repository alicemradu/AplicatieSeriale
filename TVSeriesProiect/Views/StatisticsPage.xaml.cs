using Microcharts;
using TVSeriesProiect.Models;
using TVSeriesProiect.Services;

namespace TVSeriesProiect.Views
{
    public partial class StatisticsPage : ContentPage
    {
        private DataService dataService;
        private List<string> genres = new List<string>();
        private List<TVSerie> movieList = new List<TVSerie>();

        public StatisticsPage(DataService dataService)
        {
            InitializeComponent();
            this.dataService = dataService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (movieList.Count == 0)
            {
                movieList = await dataService.GetAllTVSeries();
            }

            pickerNumber.ItemsSource = new List<string> { "2", "5" }; // Opțiuni 2 și 5
            pickerNumber.SelectedIndex = 0;

            getAllGenres();
            genrePicker.ItemsSource = genres;
            genrePicker.SelectedIndex = 0;

            drawBasedOnSelections();
        }

        private void drawBasedOnSelections()
        {
            List<TVSerie> movieListForDrawing = new List<TVSerie>();
            List<ChartEntry> chartEntries = new List<ChartEntry>();

            int numberOfMovies = 0;
            if (pickerNumber.SelectedItem != null)
            {
                numberOfMovies = int.Parse(pickerNumber.SelectedItem.ToString());
            }

            numberOfMovies = numberOfMovies == default(int) ? 3 : numberOfMovies;

            string genre = "";
            if (genrePicker.SelectedItem != null)
            {
                genre = genrePicker.SelectedItem.ToString();
            }

            genre = genre.Equals(default(string)) ? "Drama" : genre;

            foreach (TVSerie m in movieList)
            {
                if (m.Genre.Contains(genre))
                {
                    movieListForDrawing.Add(m);
                }
            }

            movieListForDrawing = movieListForDrawing.Take(numberOfMovies).ToList();

            var random = new Random();

            foreach (TVSerie movie in movieListForDrawing)
            {
                float votes = float.Parse(movie.imdbVotes.Replace(",", ""));
                string title = movie.Title;

                if (title.Length >= 15)
                {
                    title = title.Substring(0, 15) + "...";
                }

                ChartEntry entry = new ChartEntry(votes)
                {
                    Label = title,
                    ValueLabel = movie.imdbVotes,
                    Color = new SkiaSharp.SKColor(
                        (byte)random.Next(256),
                        (byte)random.Next(156),
                        (byte)random.Next(220))  // Culoare aleatorie pentru bare
                };

                chartEntries.Add(entry);
            }

            tvChart.Chart = new BarChart()
            {
                Entries = chartEntries,
                LabelTextSize = 30,  // Mărimea textului pentru etichete
                BackgroundColor = SkiaSharp.SKColor.Parse("#171717") // Folosim culoarea de fundal închisă a aplicației pentru grafic
            };
        }

        private void getAllGenres()
        {
            foreach (TVSerie movie in movieList)
            {
                string genreFromDB = movie.Genre;
                string[] splitResult = genreFromDB.Split(',');

                foreach (string genre in splitResult)
                {
                    var genreTrim = genre.Trim();
                    if (!genres.Contains(genreTrim))
                    {
                        genres.Add(genreTrim);
                    }
                }
            }
        }

        private void pickerNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawBasedOnSelections();
        }

        private void genrePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawBasedOnSelections();
        }
    }
}
