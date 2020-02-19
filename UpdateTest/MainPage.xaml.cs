using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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

        private void LaunchApk()
        {

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

        private void OldSdk()
        {
            //https://www.c-sharpcorner.com/article/how-to-download-files-in-xamarin-forms/
            WebClient webClient = new WebClient();
            string pathToNewFolder = Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "test");
            Directory.CreateDirectory(pathToNewFolder);
            string url = "http://www.benjaminrush.info/com.companyname.updatetest-Signed.apk.zip";
            string pathToNewFile = Path.Combine(pathToNewFolder, "com.companyname.updatetest-Signed.apk");
            webClient.DownloadFile(url, pathToNewFile);

            Intent promptInstall = new Intent(Intent.ActionView);
            promptInstall.SetFlags(ActivityFlags.NewTask);
            //promptInstall.AddFlags(ActivityFlags.GrantReadUriPermission);

            Android.Net.Uri uri = Android.Net.Uri.FromFile(new Java.IO.File(pathToNewFile));
            promptInstall.SetDataAndType(uri, "application/vnd.android.package-archive"); 
            //promptInstall.SetDataAndType(Android.Net.Uri.Parse("file://" + pathToNewFile), "application/vnd.android.package-archive");
            Android.App.Application.Context.StartActivity(promptInstall);

        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            OldSdk(); 
        }
    }
}
