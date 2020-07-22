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

namespace CarbonFootprintApp.ViewModels
{
    class WeeklyInputPageViewModel : INotifyPropertyChanged
    {
        int milesDriven;
        double naturalGasBill;
        double electricityBill;
        double fuelOilBill;
        double propaneBill;
        string[] recycleables;

        WeeklyInputPageViewModel()
        {
            SubmitCommand = new Command(() =>
            {
                int carbonFootprint = Calculator.calculateCarbonFootprint(MilesDriven, NaturalGasBill, ElectricityBill, FuelOilBill, PropaneBill, Recycleables);
                List<Microcharts.Entry> entries = JObject.Parse(Preferences.Get("entries", "null")).ToObject<List<Microcharts.Entry>>();
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

        public string[] Recycleables
        {
            get => recycleables;
            set
            {
                recycleables = value;

                var args = new PropertyChangedEventArgs(nameof(Recycleables));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SubmitCommand { get; }

    }
}
