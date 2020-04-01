using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonicaLoanApp.Droid.Dependencies;
using MonicaLoanApp.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(CloseAppService))]
namespace MonicaLoanApp.Droid.Dependencies
{
    public class CloseAppService : ICloseAppService
    {
        public CloseAppService()
        { }

        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}