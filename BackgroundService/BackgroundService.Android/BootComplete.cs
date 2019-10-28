using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace BackgroundService.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted, Intent.ActionAirplaneModeChanged })]
    public class BootComplete : BroadcastReceiver
    {
        #region implemented abstract members of BroadcastReceiver
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == Intent.ActionBootCompleted)
            {
                Toast.MakeText(context, "ExampleService is Working!", ToastLength.Long).Show();
                context.StartServiceCompat<ExampleService>();
            }
        }
        #endregion
    }
}