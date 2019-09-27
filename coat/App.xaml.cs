using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Media;

namespace coat
{
    public partial class App : Application
    {
        public App(MediaPlayer player)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(player));
            // new Charts();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
