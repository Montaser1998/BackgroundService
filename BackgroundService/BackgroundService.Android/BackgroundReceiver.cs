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
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace BackgroundService.Droid
{
    [Service(Name = "com.companyname.test.ExampleService")]
    public class ExampleService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public override void OnCreate()
        {
            base.OnCreate();
        }
        public const string CHANNEL_ID = "MyApplication";
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            string input = intent.GetStringExtra("inputExtra");

            Intent notificationIntent = new Intent(this, typeof(MainActivity));
            PendingIntent pendingIntent = PendingIntent.GetActivity(this,
                0, notificationIntent, 0);
            int index = 1;
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Notification notification = new Notification.Builder(this, CHANNEL_ID)
                .SetContentTitle("Example Service")
                .SetContentText(input)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentIntent(pendingIntent)
                .Build();

                StartForeground(index, notification);

                index += 1;
                return true;
            });

            return StartCommandResult.NotSticky;
        }
    }
}