using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.TextToSpeech;
using Android.Media;



namespace coat
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MediaPlayer p;

        double level = Battery.ChargeLevel;


        public MainPage(MediaPlayer player)
        {

            InitializeComponent();
            Battery.BatteryInfoChanged += Battery_BatteryInfoChanged;
            this.p = player;
            
    }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            BatteryStats();
            SetCollor();
            
            

        }


        private void Battery_BatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            BatteryStats();
            SetCollor();
        }


        public void BatteryStats()
        {
           

            var state = Battery.State;

            switch (state)
            {
                case BatteryState.Charging:
                    // Currently charging
                    break;
                case BatteryState.Full:
                    // Battery is full
                    break;
                case BatteryState.Discharging:
                case BatteryState.NotCharging:
                    // Currently discharging battery or not being charged
                    break;
                case BatteryState.NotPresent:
                // Battery doesn't exist in device (desktop computer)
                case BatteryState.Unknown:
                    // Unable to detect battery state
                    break;
            }

            var source = Battery.PowerSource;

            switch (source)
            {
                case BatteryPowerSource.Battery:
                    // Being powered by the battery
                    break;
                case BatteryPowerSource.AC:
                    // Being powered by A/C unit
                    break;
                case BatteryPowerSource.Usb:
                    // Being powered by USB cable
                    break;
                case BatteryPowerSource.Wireless:
                    // Powered via wireless charging
                    break;
                case BatteryPowerSource.Unknown:
                    // Unable to detect power source
                    break;
            }

            LabelLevel.Text = "Level: " + level + "";
            LabelState.Text = "State: " + state + "";
            LabelPowersource.Text = "PowerSource: " + source + "";
        }


        public void SetCollor()
        {
         

            if (level > 0.5)
            {
                page.BackgroundColor = Xamarin.Forms.Color.Green;
            }

            if (level < 0.5)
            {
                page.BackgroundColor = Xamarin.Forms.Color.Orange;
            }

            if (level < 0.2)
            {
                CrossTextToSpeech.Current.Speak("Battery level low! Battery is under 20%");
                DisplayAlert("Battery level low!", "Battery is under 20%", "OK");
               
                Vibration.Vibrate(TimeSpan.FromSeconds(1));
                page.BackgroundColor = Xamarin.Forms.Color.Red;
            }
        }

        // Navigation

        private void ChangeToVPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new vibrationPage());
        }

        private void ChangeToTPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TextToS());
        }

        private void ChangeToCPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Charts());
        }



        private async void DrainBattery(object sender, EventArgs e)
        {

            await CrossTextToSpeech.Current.Speak("i am draining all of your battery now, please sit back and enjoy this completely unnecessary feature");
            p.Start();

            
            Vibration.Vibrate(TimeSpan.FromSeconds(100));

            // C:\Users\hasss\Documents\Visual Studio 2019\MobileApps\coat\coat.Android\Resources\song\Bob-Marley-Buffalo-Soldier.mp3
            try  {
                for (int i = 0; i < 100; i++) {
                    // Turn On
                    await Flashlight.TurnOnAsync();

                    // Turn Off
                    await Flashlight.TurnOffAsync();

                }

                
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to turn on/off flashlight
            }

            


        }
    }
}
