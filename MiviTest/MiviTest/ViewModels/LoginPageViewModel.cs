using MiviTest.Models;
using MiviTest.Views;
using MvvmHelpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiviTest.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly INavigation navigation;

        private string email;

        public string Email
        {
            get { return email; }

            set { SetProperty(ref email, value); }
        }

        private string password;

        public string Password
        {
            get { return password; }

            set { SetProperty(ref password, value); }
        }

        private Command loginCommand { get; set; }

        public Command LoginCommand => loginCommand
                                          ?? (loginCommand = new Command(async () => await OnLoginClickedAsync()));

        public LoginPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;

            LoadCredentials();//for quick access
        }

        private void LoadCredentials()
        {
            Email = "test@mivi.com";
            Password = "letmein";
        }

        private async Task OnLoginClickedAsync()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await ShowAlertMessage("Fields cannot be empty");
            }
            else
            {
                var loginResult = ValidateCredentials();

                if (loginResult.IsValid)
                {
                    await navigation.PushModalAsync(new MiviSplashPage(loginResult.Result));
                }
                else
                {
                    await ShowAlertMessage("Invalid credentials");
                }
            }
        }

        private LoginResult ValidateCredentials()
        {
            var login = new LoginResult();

            var collection = CommonFunctions.GetCollection();

            var emailAddress = collection.Data.Attributes.EmailAddress;
            if (emailAddress != Email || Password != "letmein")
            {
                login.IsValid = false;

                return login;
            }
            else
            {
                login.IsValid = true;
                login.Result = collection;
                return login;
            }
        }

        private static async Task ShowAlertMessage(string messsage)
        {
            await Application.Current.MainPage.DisplayAlert("Alert", messsage, "Ok");
        }
    }
}