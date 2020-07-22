﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CarbonFootprintApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class WeeklyInputPage : ContentPage
    {
        public WeeklyInputPage()
        {
            InitializeComponent();
            picker.ItemsSource = new List<string>() { "hello", "goodbye" };

            if(Preferences.Get("first time", true))
            {
                Navigation.PushModalAsync(new FirstTimePage());
                Preferences.Set("first time", false);
            }
        }


    }
}