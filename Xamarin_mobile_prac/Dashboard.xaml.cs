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
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
        }
        public string WebAPIKey = "AIzaSyA_BrkvPoM2xy5OPOxJoJCAaLJgHgCJEZk";
        async void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIKey));
            try
            {   //Token saved during login
                var savedFirebaseAuth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //refresh token
                var refreshedContent = await authProvider.RefreshAuthAsync(savedFirebaseAuth);
                Preferences.Set("MyFirebaseRefreshtToken", JsonConvert.SerializeObject(refreshedContent));
                //grab info
                MyUserName.Text
            }
        }

        private void Logout_Clicked(object sender, EventArgs e)
        {

        }
    }
}