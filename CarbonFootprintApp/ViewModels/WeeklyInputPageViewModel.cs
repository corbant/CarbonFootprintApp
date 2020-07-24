using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microcharts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms.Internals;

namespace CarbonFootprintApp.ViewModels
{
    public class WeeklyInputPageViewModel : INotifyPropertyChanged
    {
        int milesDriven;
        double naturalGasBill;
        double electricityBill;
        double fuelOilBill;
        double propaneBill;

        public WeeklyInputPageViewModel()
        {
            SubmitCommand = new Command(() =>
            {
                int carbonFootprint = Calculator.calculateCarbonFootprint(MilesDriven, NaturalGasBill, ElectricityBill, FuelOilBill, PropaneBill, new string[5]);
                List<Microcharts.Entry> entries;
                if (!Preferences.ContainsKey("entries"))
                {
                    entries = new List<Microcharts.Entry>();
                }
                else
                {
                    entries = JObject.Parse(Preferences.Get("entries", "null")).ToObject<List<Microcharts.Entry>>();
                }
                entries.Add(new Microcharts.Entry(carbonFootprint)
                {
                    Label = DateTime.Now.Date.ToString(),
                    ValueLabel = carbonFootprint.ToString(),
                    Color = SKColors.Blue,
                    TextColor = SKColors.Black
                });
                Preferences.Set("entries", JsonConvert.SerializeObject(entries));
            });
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public int MilesDriven
        {
            get => milesDriven;
            set
            {
                milesDriven = value;

                var args = new PropertyChangedEventArgs(nameof(MilesDriven));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public double NaturalGasBill
        {
            get => naturalGasBill;
            set
            {
                naturalGasBill = value;

                var args = new PropertyChangedEventArgs(nameof(NaturalGasBill));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public double ElectricityBill
        {
            get => electricityBill;
            set
            {
                electricityBill = value;

                var args = new PropertyChangedEventArgs(nameof(ElectricityBill));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public double FuelOilBill
        {
            get => fuelOilBill;
            set
            {
                fuelOilBill = value;

                var args = new PropertyChangedEventArgs(nameof(FuelOilBill));

                PropertyChanged?.Invoke(this, args);
            }
        }


        public double PropaneBill
        {
            get => propaneBill;
            set
            {
                propaneBill = value;

                var args = new PropertyChangedEventArgs(nameof(PropaneBill));

                PropertyChanged?.Invoke(this, args);
            }
        }

        //recycling stuff

        public IEnumerable<string> Recycleables
        {
            get
            {
                return new List<string>() {
                    "Cans", "Plastic", "Glass", "Newspapers", "Magazines"
                };
            }
        }
        

        ObservableCollection<string> selectedRecycling;

        public ObservableCollection<string> SelectedRecycling
        {
            get => selectedRecycling;
            set
            {
                if(selectedRecycling != value)
                {
                    selectedRecycling = value;
                }
            }
        }

        

        public Command SubmitCommand { get; }

    }

    public class Recycleable
    {
        public string Name { get; set; }
    }

    
}
