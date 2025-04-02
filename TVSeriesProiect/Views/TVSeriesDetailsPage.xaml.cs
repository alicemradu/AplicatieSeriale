using TVSeriesProiect.Models;
using TVSeriesProiect.Services;
namespace TVSeriesProiect.Views;

[QueryProperty(nameof(Title), "title")]
public partial class TVSeriesDetailsPage : ContentPage
{
    List<TVSerie> tvSeriesList = new List<TVSerie>();
    string title = "Breaking Bad";
    DataService dataService; //pt citire date din bd
    public string Title
    {
        set
        {
            title = value;
        }
    }
    public TVSeriesDetailsPage(DataService dataService)
    {
        InitializeComponent();
        this.dataService = dataService;

    }

    protected override async void OnAppearing() //cand se incarca pagina
    {
        base.OnAppearing();

        //citire date db
        tvSeriesList = await dataService.GetAllTVSeries();
        if (tvSeriesList.Count == 0)//daca nu le gasim 
        {
            tvSeriesList = await dataService.GetAllTVSeries();
        }

        foreach (TVSerie s in tvSeriesList)
        {
            if (s.Title.Equals(title))
            {
                img_aboutTVSerie.Source = s.Poster;
                labelTitle_aboutTVSerie.Text = s.Title;
                labelReleased_aboutTVSerie.Text = s.Released;
                labelTime_aboutTVSerie.Text = "Duration:" + s.Time.ToString();
                labelLanguage_aboutTVSerie.Text = s.Language;
                labelGenre_aboutTVSerie.Text = s.Genre.ToString();
                spanActors_TVSeriePage.Text = s.Actors.ToString();
                spanDescription_TVSeriePage.Text = s.Plot.ToString();
                labelRating_TVSeriePage.Text = "Rating: " + s.Rating.ToString();
                labelVotes_TVSeriePage.Text = " Votes: " + s.imdbVotes.ToString();
                break;
            }
        }
    }
}