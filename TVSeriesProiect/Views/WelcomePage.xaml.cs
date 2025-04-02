namespace TVSeriesProiect.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnWelcomePageClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//TVSeriesListPage");
        }
    }
}
