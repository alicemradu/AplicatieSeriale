using TVSeriesProiect.Models;
using TVSeriesProiect.Services;

namespace TVSeriesProiect.Views;

public partial class ActorListPage : ContentPage
{
    List<TVSerie> tvseriesList = new List<TVSerie>();
    TopTVSeriesService tvseriesService;
    DataService dataService;
    ActorDataService actorDataService;
    List<Actor> actorsList = new List<Actor>();

    public ActorListPage(TopTVSeriesService tvseriesService, DataService dataService, ActorDataService actorDataService)
    {
        InitializeComponent();
        this.tvseriesService = tvseriesService;
        this.dataService = dataService;
        this.actorDataService = actorDataService;
    }

    private void OnActorDetailsButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        if (button?.CommandParameter is Actor actor)
        {
            Shell.Current.GoToAsync($"ActorDetailsPage?actor={actor.Name}");
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (tvseriesList.Count == 0)
        {
            await InitList();
        }

        if (actorsList.Count == 0)
        {
            await InitListActors();
        }
        lvActors_actorListPage.ItemsSource = actorsList;
    }

    async Task InitList()
    {
        // citire db
        if (tvseriesList.Count == 0)
        {
            tvseriesList = await dataService.GetAllTVSeries();
        }
    }

    async Task InitListActors()
    {
        // preluare actori din db
        actorsList = await actorDataService.GetAllActors();
        if (actorsList.Count == 0)
        {
            InitActorsTable();
        }
    }

    private async void InitActorsTable()
    {
        List<string> actors = new List<string>();
        foreach (TVSerie tvSerie in tvseriesList)
        {
            string actorsFromDB = tvSerie.Actors; // Preluare actori ca string
            string[] splitResult = actorsFromDB.Split(','); // Split după separator
            foreach (string actor in splitResult)
            {
                var actorTrim = actor.Trim();
                if (!actors.Contains(actorTrim))
                {
                    actors.Add(actorTrim);
                    Actor a = new Actor(actorTrim);
                    actorsList.Add(a);
                }
                else
                {
                    foreach (Actor a in actorsList)
                    {
                        if (a.Name.Equals(actorTrim))
                        {
                            a.NumberOfTVSeriesInTop++;
                        }
                    }
                }
            }
        }
        // inserare actori in db
        await actorDataService.InsertActorsList(actorsList);
    }
}
