using System;

using Android.App;
using Android.Content;
using System.Text;
using System.Linq;
using Android.Util;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Android.Provider;
using Android.Database;
using Java.Util;
using TheHealthyAssistant.Services;

namespace TheHealthyAssistant.Droid
{
    [Activity(Label = "TheHealthyAssistant", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            GPSService gPSService = new GPSService();
            SmsService smsService = new SmsService(gPSService);
            GyroscopeService gyroscopeService = new GyroscopeService(smsService);
             
            gyroscopeService.ToggleGyroscope();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }
    }
}