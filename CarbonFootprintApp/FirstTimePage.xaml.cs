using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarbonFootprintApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstTimePage : ContentPage
    {
        public FirstTimePage()
        {
            InitializeComponent();

            naturalGasPicker.ItemsSource = yesno;
        }

        List<string> yesno = new List<String>() { "yes", "no" };
    }
}