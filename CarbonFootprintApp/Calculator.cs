using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CarbonFootprintApp
{
    public static class Calculator
    {

        public static double getAreaEmission(int zipcode)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Calculator)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("CarbonFootprintApp.data.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            JObject thing = JObject.Parse(text);
            var result = thing["EGRID_DATA"].FirstOrDefault(i => i["Zip"].ToString() == zipcode.ToString());
            double emissionRate = 0;
            if (result != null)
            {
                emissionRate = result["annual emission rate"].ToObject<double>();
            }
            return emissionRate;
        }

        public static int calculateCarbonFootprint(int milesDriven, double naturalGasBill, double electricityBill, double fuelOilBill, double propaneBill, string[] recycleables)
        {
            double carbonFootprint = 0;
            int numPeople = Preferences.Get("numPeople", 3);

            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(Calculator)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("CarbonFootprintApp.data.txt");
            string text = "";
            using (var reader = new System.IO.StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            JToken values = JObject.Parse(text)["Values"];

            /* car calculations:
             * miles driven this week / fuel efficiency * EF_passenger_vehicle * nonCO2_vehicle_emissions_ratio */
            carbonFootprint += milesDriven / Preferences.Get("vehicleMPG", getValue(values, "average_mpg")) * getValue(values, "EF_passenger_vehicle") * getValue(values, "nonCO2_vehicle_emissions_ratio");

            /* natural gas calculation
             * (bill amount / Natural_gas_cost_1000CF) * EF_natural_gas / weeks in a month */
            carbonFootprint += naturalGasBill / getValue(values, "Natural_gas_cost_1000CF") * getValue(values, "EF_natural_gas") / 4;

            /* electricity calculation
             * (bill amount / cost_per_kWh) )* e_factor_value / weeks in a month */
            carbonFootprint += electricityBill / getValue(values, "cost_per_kWh") * getAreaEmission(Preferences.Get("zipcode", 00002)) /1000 / 4;

            /* fuel oil calculation
             * (bill amount / fuel_oil_cost) * EF_fuel_oil_gallon / weeks in a month */
            carbonFootprint += fuelOilBill / getValue(values, "fuel_oil_cost") * getValue(values, "EF_fuel_oil_gallon") / 4;

            /* propane calculation
             * (bill amount / propane_cost) * EF_propane / weeks in a month */
            carbonFootprint += propaneBill / getValue(values, "propane_cost") * getValue(values, "EF_propane") / 4;

            /* waste calculation
             * (number of people in house * average_waste_emissions) - (number of people in house * avoided emmisions for each type)*/
            carbonFootprint += numPeople * getValue(values, "average_waste_emissions");
            if (recycleables.Contains("cans")) { carbonFootprint += numPeople * getValue(values, "metal_recycling_avoided_emissions"); }
            if(recycleables.Contains("plastic")) { carbonFootprint += numPeople * getValue(values, "plastic_recycling_avoided_emissions"); }
            if (recycleables.Contains("glass")) { carbonFootprint += numPeople * getValue(values, "glass_recycling_avoided_emissions"); }
            if (recycleables.Contains("newspaper")) { carbonFootprint += numPeople * getValue(values, "newspaper_recycling_avoided_emissions"); }
            if (recycleables.Contains("magazine")) { carbonFootprint += numPeople * getValue(values, "mag_recycling_avoided_emissions"); }


            /* carbon footprint = sum of all*/

            return (int) carbonFootprint;
        }

        private static double getValue(JToken values, string searchValue)
        {
            return values.FirstOrDefault(i => i["Name"].ToString() == searchValue)["Value"].ToObject<double>();
        }
    }
}
