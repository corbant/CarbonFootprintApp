using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonFootprintApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

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
