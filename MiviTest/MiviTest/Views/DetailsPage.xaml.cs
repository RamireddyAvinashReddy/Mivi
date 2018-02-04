using MiviTest.Models;
using MiviTest.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiviTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage(Result details)
        {
            InitializeComponent();

            BindingContext = new DetailsPageViewModel(details);
        }
    }
}