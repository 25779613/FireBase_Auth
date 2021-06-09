using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_mobile_prac
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public string WebAPIKey = "AIzaSyA_BrkvPoM2xy5OPOxJoJCAaLJgHgCJEZk";
        public Login()
        {
            InitializeComponent();
        }

        async void loginbutton_Clicked(object sender, EventArgs e)
        {

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));

            try
            {
                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();//
                var SerailizedContent = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", SerailizedContent);
                await Navigation.PushAsync(new Dashboard());

            }catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Invalid credentials", "Re-try", "Ok");
            }
        }

        async void signupbutton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Alert", gettoken, "Ok");
            }catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "ok");
            }
        }
    }
}