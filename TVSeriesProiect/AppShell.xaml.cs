using TVSeriesProiect.Views;
namespace TVSeriesProiect
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("TVSeriesDetailsPage", typeof(TVSeriesDetailsPage));
            Routing.RegisterRoute("ActorDetailsPage", typeof(ActorDetailsPage));


        }
    }
}
