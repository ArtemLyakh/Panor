using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Panor
{
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current;

		private Pages.Core.MenuPage Menu => (Pages.Core.MenuPage)((MasterDetailPage)MainPage).Master;
		private NavigationPage NavPage => (NavigationPage)((MasterDetailPage)MainPage).Detail;

        public void CloseMenu()
        {
            ((MasterDetailPage)MainPage).IsPresented = false;
        }


        private Navigation _navigation;
        public Navigation Navigation
        {
            get
            {
                if (_navigation == null)
                {
                    _navigation = new Navigation(NavPage);
                }
                return _navigation;
            }
        }

        private Services.Auth.AuthService _authService;
        public Services.Auth.AuthService AuthService
        {
            get 
            {
                if (_authService == null)
                {
                    _authService = new Services.Auth.AuthService();
                }
                return _authService;
            }
        }




        public App()
        {
            InitializeComponent();

            var ignore = new FFImageLoading.Transformations.CircleTransformation();

            MainPage = new Pages.Core.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public class Navigation 
    {
        private NavigationPage NavPage;

        public Navigation(NavigationPage navPage)
        {
            NavPage = navPage;
        }

        public Task PopToRoot(bool animated = true) => NavPage.PopToRootAsync(animated);
        public Task Push(Page page, bool animated = true) => NavPage.PushAsync(page, animated);
        public Task Pop(bool animated = true) => NavPage.PopAsync(animated);
        public async Task PushRoot(Page page, bool animated = true)
        {
            await PopToRoot(false);
            await Push(page, animated);
        }

    }
}
