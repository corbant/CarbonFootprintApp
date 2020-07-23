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
    public class FirstTimePageViewModel : INotifyPropertyChanged
    {

        double vehicleMPG;
        int zipcode;
        int numPeople;

        public FirstTimePageViewModel()
        {
            SubmitCommand = new Command(() =>
            {
                Preferences.Set("vehicleMPG", VehicleMPG);
                Preferences.Set("zipcode", Zipcode);
                Preferences.Set("numPeople", NumPeople);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public double VehicleMPG
        {
            get => vehicleMPG;
            set
            {
                vehicleMPG = value;

                var args = new PropertyChangedEventArgs(nameof(VehicleMPG));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public int Zipcode
        {
            get => zipcode;
            set
            {
                zipcode = value;

                var args = new PropertyChangedEventArgs(nameof(Zipcode));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public int NumPeople
        {
            get => numPeople;
            set
            {
                numPeople = value;

                var args = new PropertyChangedEventArgs(nameof(NumPeople));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public IEnumerable<string> Recycleables
        {
            get
            {
                return new List<string>() {
                    "Cans", "Plastic", "Glass", "Newspapers", "Magazines"
                };
            }
        }


        ObservableCollection<object> selectedRecycling;

        public ObservableCollection<object> SelectedRecycling
        {
            get => selectedRecycling;
            set
            {
                if (selectedRecycling != value)
                {
                    selectedRecycling = value;
                }
            }
        }

        public class Recycleable
        {
            public string Name { get; set; }
        }


        public Command SubmitCommand { get; }
    }
}
