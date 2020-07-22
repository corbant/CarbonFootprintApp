using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

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

        public Command SubmitButton;

    }
}
