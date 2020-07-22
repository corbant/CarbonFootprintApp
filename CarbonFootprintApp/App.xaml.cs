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

            /*TODO: make first time page appear if its the first time
            
            Application.Current.Properties["first time"] = true;
            if (Application.Current.Properties.ContainsKey("first time") && (bool) Application.Current.Properties["first time"])
            {
                Page firstTimePage = new FirstTimePage();
            }*/
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
