using coat.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using coat.ViewModel;

namespace coat.ViewModel
{
     class BatteryViewModel
    {

        public List<batteryInfo> BatteryLife{ get; set; }
        public BatteryViewModel()
        {

            try
            {
                BatteryLife.Add(new batteryInfo { BatteryLevel = 0.20, Label = "Battery" });
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("intet retur");
            }
           
            }
    }
}
