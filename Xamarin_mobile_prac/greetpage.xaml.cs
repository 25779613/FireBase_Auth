using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_mobile_prac
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class greetpage : ContentPage
    {
        public greetpage()
        {
            InitializeComponent();
            slider2.Value = 0.5;
            //dynamic input of code
         /*   Content = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Text = "Hi Dev"
            };*/
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Title","Hello You","Bye");
            greetLabel.Text = "Stop changing me";
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            greetLabel.Text = String.Format("Value is {0:F2}",e.NewValue);
        }
    }
}