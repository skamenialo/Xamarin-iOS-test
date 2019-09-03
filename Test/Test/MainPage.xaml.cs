using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Skip)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            //DependencyService.Resolve<Iapp>().OpenScreen();
            Application.Current.MainPage.Navigation.PushAsync(App.CreatePage(typeof(TabbedPage1)));
        }
    }
}
