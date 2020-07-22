using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.Entry;
using SkiaSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace CarbonFootprintApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        List<Entry> entries;
        public GraphPage()
        {
            InitializeComponent();
            entries = JObject.Parse(Preferences.Get("entries", "null")).ToObject<List<Entry>>();
            chart.Chart = new LineChart() { Entries = entries };
        }
    }
}