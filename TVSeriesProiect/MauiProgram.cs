using Microcharts.Maui;
using Microsoft.Extensions.Logging;
using TVSeriesProiect.Services;
using TVSeriesProiect.Views;

namespace TVSeriesProiect
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<TopTVSeriesService>();
            builder.Services.AddSingleton<DataService>();
            builder.Services.AddSingleton<ActorDataService>();

            builder.Services.AddTransient<TVSeriesListPage>();
            builder.Services.AddTransient<TVSeriesDetailsPage>();
            builder.Services.AddTransient<ActorListPage>();
            builder.Services.AddTransient<ActorDetailsPage>();
            builder.Services.AddTransient<StatisticsPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
