using System;
using System.Collections.Generic;
using Finance.Model;
using Xamarin.Forms;

namespace Finance.View
{
    public partial class PostPage : ContentPage
    {
        public PostPage()
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
        }

        public PostPage(Item item)
        {
            InitializeComponent();
            Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);

            webView.Source = "https://stackoverflow.com/questions/52793957/xamarin-forms-display-image-from-embedded-resource-using-xaml";
        }
    }
}
