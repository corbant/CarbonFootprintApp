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

        List<Entry> entries = new List<Entry>() {
            new Entry(10) {
                Label = "5/2/20",
                Color = SKColor.Parse("#ebe834"),
                ValueLabel = "10"
            },
            new Entry(8)
            {
                Label = "5/9/20",
                Color = SKColor.Parse("#34c3eb"),
                ValueLabel = "8"
            },
            new Entry(7)
            {
                Label = "5/16/20",
                Color = SKColor.Parse("#eb34cc"),
                ValueLabel = "7"
            }
        };
        public GraphPage()
        {
            InitializeComponent();
            entries = JObject.Parse(Preferences.Get("entries", "null")).ToObject<List<Entry>>();
            chart.Chart = new LineChart() { Entries = entries };
        }
    }
}