using TVSeriesProiect.Models;
using TVSeriesProiect.Services;

namespace TVSeriesProiect.Views;

[QueryProperty(nameof(Name), "actor")]
public partial class ActorDetailsPage : ContentPage
{
    List<TVSerie> tvSeriesList = new List<TVSerie>();
    List<Actor> actors = new List<Actor>();
    string name = "";
    DataService dataService;
    ActorDataService actorDataService;

    public ActorDetailsPage(DataService dataService, ActorDataService actorDataService)
    {
        InitializeComponent();
        this.dataService = dataService;
        this.actorDataService = actorDataService;
    }

    public string Name
    {
        set { name = value; }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (actors.Count == 0)
        {
            await InitList();
        }

        var actor = actors.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (actor != null)
        {
            labelName_actorDetailsPage.Text = actor.Name;
            labelNumberOfTVSeries_actorDetailsPage.Text = actor.NumberOfTVSeriesInTop.ToString();
        }
        tvSeriesList = await dataService.GetAllTVSeriesByActor(name);
        collectionViewTVSeries_actorDetailsPage.ItemsSource = tvSeriesList;
    }

    async Task InitList()
    {
        if (actors.Count == 0)
        {
            actors = await actorDataService.GetAllActorsByName(name);
        }
    }
}
