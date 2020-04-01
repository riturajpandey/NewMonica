using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using Plugin.CurrentActivity;
using Plugin.Permissions;

namespace MonicaLoanApp.Droid
{
    [Activity(Label = "MonicaLoanApp", Icon = "@drawable/fav", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
           
            #region Initializing Packages   
            UserDialogs.Init(this); 
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
             
            Rg.Plugins.Popup.Popup.Init(this, savedInstanceState);
            Plugin.InputKit.Platforms.Droid.Config.Init(this, savedInstanceState);
             
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;   
            #endregion
            LoadApplication(new App());
            #region Status Bar
            //To set Status Bar Color :
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#0984e3"));

            #endregion
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
    }
}