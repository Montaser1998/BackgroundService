using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using services = BackgroundService.Droid.Services;
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
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            string input = intent.GetStringExtra("inputExtra");

            Intent notificationIntent = new Intent(this, typeof(MainActivity));
            PendingIntent pendingIntent = PendingIntent.GetActivity(this, 0, notificationIntent, 0);
            var notification = new NotificationCompat.Builder(this, services.CHANNEL_ID)
            .SetContentTitle("Example Service")
            .SetContentText(input)
            .SetContentIntent(pendingIntent)
            .SetSmallIcon(Resource.Drawable.icon)
            .SetPriority((int)NotificationImportance.None)
            .Build();
            StartForeground(1, notification);
            return StartCommandResult.NotSticky;
        }
    }
}