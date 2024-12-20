using ToDoo.Views;
namespace ToDoo
{
    public partial class App : Application
    {
        public App(MainView view)
        {
            InitializeComponent();
            MainPage = new NavigationPage(view);
        }
    }
}