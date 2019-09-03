using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
		public Page2 ()
		{
			InitializeComponent ();
		}

        private async void Button_Pressed(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(App.CreatePage(typeof(Page3)));
        }

        private async void Button_Pressed2(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        }

        private async void Button_Pressed3(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopToRootAsync();
        }
    }
}