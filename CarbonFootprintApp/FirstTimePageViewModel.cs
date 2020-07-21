using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CarbonFootprintApp
{
    class FirstTimePageViewModel : INotifyPropertyChanged
    {

        public FirstTimePageViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        Command SubmitCommand { get; }
    }
}
