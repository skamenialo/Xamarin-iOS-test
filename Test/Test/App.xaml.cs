using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Test
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Application.Current.MainPage = new NavigationView(CreatePage(typeof(MainPage)));
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

        public static Page CreatePage(Type page)
        {
            try
            {
                return Activator.CreateInstance(page) as Page;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
