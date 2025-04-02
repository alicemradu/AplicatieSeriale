using TVSeriesProiect.Models;
using TVSeriesProiect.Services;

namespace TVSeriesProiect.Views;

public partial class TVSeriesListPage : ContentPage
{
    List<TVSerie> tvSeriesList = new List<TVSerie>();
    TopTVSeriesService tvSeriesService;
    DataService dataService;

    public TVSeriesListPage(TopTVSeriesService tvSeriesService, DataService dataService)
    {
        InitializeComponent();
        this.tvSeriesService = tvSeriesService;
        this.dataService = dataService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (tvSeriesList.Count == 0)
        {
            await InitList();
        }
        if (tvSeriesList.Count > 0)
        {
            BindingContext = tvSeriesList[0];
        }
        lvTVSeries_listPage.ItemsSource = tvSeriesList;
    }

    async Task InitList()
    {
        tvSeriesList = await dataService.GetAllTVSeries();

        if (tvSeriesList.Count == 0)
        {
            tvSeriesList = await tvSeriesService.DownloadAndParseJsonTVSeriesAsync();
            await dataService.InsertTVSeriesList(tvSeriesList);
        }
    }

    private async void Image_Loaded_ListPage(object sender, EventArgs e)
    {
        var image = (Image)sender;
        try
        {
            var res = await image.Source.GetPlatformImageAsync(Handler.MauiContext);
        }
        catch (InvalidOperationException ex)
        {
            if (ex.Message.Contains("status code NotFound"))
            {
                // img locala in cazul in care imaginea din JSON nu mai este valabila
                image.Source = "default_image.jpg";
            }
        }
    }

    private async void BtnInfo_listPage_clicked(object sender, EventArgs e)
    {
        var buttton = (Button)sender;
        var selectedItem = (TVSerie)buttton.BindingContext;
        await Shell.Current.GoToAsync($"TVSeriesDetailsPage?title={selectedItem.Title}");
    }
}
