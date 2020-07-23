using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;

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



        public Command SubmitCommand { get; }
    }
}
