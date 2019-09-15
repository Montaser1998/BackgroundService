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
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace BackgroundService.Droid
{
    [Service(Enabled = true)]
    public class PeriodicService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            var Timer = new Timer(new TimerCallback(TickTimer),
                                  null,
                                  1000,
                                  2000);

            return StartCommandResult.ContinuationMask;
        }
        int i = 0;
        private void TickTimer(object state)
        {
            Plugin.LocalNotifications.CrossLocalNotifications.Current.Show($"Local Notification Title + {i}", $"Local Notification + {i}", i);
            i++;
        }

        public override void OnDestroy()
        {
            var intent = new Intent(this, typeof(PeriodicService));
            StartService(intent);
            //base.OnDestroy();
        }
    }
}