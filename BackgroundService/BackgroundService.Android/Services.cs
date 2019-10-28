
using Android.App;
using Android.OS;
using Android.Content;
using Android.Support.V4.Content;

namespace BackgroundService.Droid
{
    public static class Services
    {
        public const string CHANNEL_ID = "MyApplication";
        public static void StartServiceCompat<T>(this Context context, Bundle args = null) where T : Service
        {
            var intent = new Intent(context, typeof(T));
            if (args != null)
            {
                intent.PutExtras(args);
            }
            NotificationChannel serviceChannel;
            var manager = context.GetSystemService(Context.NotificationService) as NotificationManager;
            serviceChannel = manager.GetNotificationChannel(CHANNEL_ID);
            if (serviceChannel == null)
            {
                serviceChannel = new NotificationChannel(CHANNEL_ID, "Example Service Channel", NotificationImportance.None);
                serviceChannel.EnableVibration(true);
                serviceChannel.EnableLights(true);
                serviceChannel.SetShowBadge(true);
                serviceChannel.LockscreenVisibility = NotificationVisibility.Public;
                manager.CreateNotificationChannel(serviceChannel);
            }
            serviceChannel?.Dispose();

            ContextCompat.StartForegroundService(context, intent);
        }
    }
}