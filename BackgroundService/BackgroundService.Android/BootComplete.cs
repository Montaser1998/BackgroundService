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
using Android.Util;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace BackgroundService.Droid
{
    [BroadcastReceiver]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class BootComplete : BroadcastReceiver
    {
        #region implemented abstract members of BroadcastReceiver
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action.Equals(Intent.ActionBootCompleted))
            {
                Toast.MakeText(context, "Action Boot Completed!", ToastLength.Long).Show();
                var serviceIntent = new Intent(context, typeof(MainActivity));
                serviceIntent.AddFlags(ActivityFlags.NewTask);
                context.StartActivity(serviceIntent);
            }
        }
        #endregion
    }
}