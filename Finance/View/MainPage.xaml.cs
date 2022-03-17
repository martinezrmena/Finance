using System;
using System.Collections.Generic;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;

namespace Finance.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);

            CrossFirebasePushNotification.Current.OnNotificationReceived += Current_OnNotificationReceived;

        }

        private void Current_OnNotificationReceived(object source, FirebasePushNotificationDataEventArgs e)
        {
            DisplayAlert("Notification", $"Data: {e.Data["myData"]}", "OK");
        }
    }
}
