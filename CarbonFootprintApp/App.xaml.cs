using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace CarbonFootprintApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if(!Preferences.ContainsKey("vehicleMPG") || !Preferences.ContainsKey("zipcode") || !Preferences.ContainsKey("numPeople"))
            {
                Preferences.Set("first time", true);
            }

            MainPage = new NavigationPage(new WeeklyInputPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
