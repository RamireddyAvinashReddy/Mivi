using MiviTest.Models;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiviTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MiviSplashPage : ContentPage
    {
        private Result _details;

        public MiviSplashPage(Result details)
        {
            InitializeComponent();

            this._details = details;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(3000);

            await Navigation.PushModalAsync(new DetailsPage(this._details), false);
        }
    }
}