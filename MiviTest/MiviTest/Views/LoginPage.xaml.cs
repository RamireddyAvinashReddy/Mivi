using MiviTest.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MiviTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginPageViewModel(Navigation);
        }
    }
}