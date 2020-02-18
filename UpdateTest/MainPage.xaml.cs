using Android.Content;
using Android.Provider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UpdateTest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LaunchMapFromClick()
        {
            var geoUri = Android.Net.Uri.Parse("geo:42.37426660,-71.12420824");
            var mapIntent = new Intent(Intent.ActionView, geoUri);
            // https://forums.xamarin.com/discussion/10232/calling-startactivity-from-outside-of-an-activity-context-requires-the-flag-activity-new-task-flag
            mapIntent.AddFlags(ActivityFlags.NewTask);
            //https://stackoverflow.com/questions/43279971/get-current-activity-xamarin-android
            Android.App.Application.Context.StartActivity(mapIntent);
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {

        }
    }
}
