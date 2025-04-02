namespace TVSeriesProiect
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            // Setează WelcomePage ca pagina principală într-un NavigationPage
            //MainPage = new NavigationPage(new Views.WelcomePage());
        }
    }
}
