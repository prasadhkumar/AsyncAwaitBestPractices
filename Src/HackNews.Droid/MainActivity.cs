﻿using Android.OS;
using Android.App;
using Android.Content.PM;

namespace HackerNews.Droid
{
    [Activity(Label = "HackerNews.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }

        [Android.Runtime.Preserve, Java.Interop.Export(nameof(GetStoriesAsBase64String))]
        public string GetStoriesAsBase64String() => BackdoorMethodServices.GetStoriesAsBase64String();
    }
}
