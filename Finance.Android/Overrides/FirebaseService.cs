using System;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Firebase.Messaging;
using WindowsAzure.Messaging;

namespace Finance.Droid.Overrides
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseService: FirebaseMessagingService
    {

        public FirebaseService()
        {
        }

        public override void OnNewToken(string token)
        {
            SendRegistrationToAzure(token);
        }

        private void SendRegistrationToAzure(string token)
        {
            try
            {
                NotificationHub hub = new NotificationHub(Helper.Constants.NotificationHubName, Helper.Constants.ListenConnectionString, this);

                Registration registration = hub.Register(token, new string[] { "default" });

                string pnsHandle = registration.PNSHandle;
                hub.RegisterTemplate(pnsHandle, "defaultTemplate", "{\"data\":{\"message\":\"Notification Hub test notification\"}}", new string[] { "default" });
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);
            string messageBody;

            if (message.GetNotification() != null)
            {
                messageBody = message.GetNotification().Body;
            }
            else
            {
                messageBody = message.Data.Values.First();
            }

            SendLocalNotification(messageBody);
        }

        private void SendLocalNotification(string messageBody)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            intent.PutExtra("message", messageBody);

            var requestCode = new Random().Next();
            var pendingIntent = PendingIntent.GetActivity(this, requestCode, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this)
                .SetContentTitle("Finance Message")
                .SetSmallIcon(Resource.Drawable.ic_launcher)
                .SetContentText(messageBody)
                .SetAutoCancel(true)
                .SetShowWhen(false)
                .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationChannel channel = new NotificationChannel(
                    "XamarinNotifyChannel",
                    "Finance App",
                    NotificationImportance.High);
                notificationManager.CreateNotificationChannel(channel);

                notificationBuilder.SetChannelId("XamarinNotifyChannel");
            }

            notificationManager.Notify(0, notificationBuilder.Build());
        }
    }
}
