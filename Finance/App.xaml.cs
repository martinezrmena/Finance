using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Finance.View;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Finance
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected async override void OnStart()
        {
            string androidAppSecret = "1f5e18b3-b721-43a7-b766-21d92e54bd2f";
            string iOSAppSecret = "ebc8b9c4-8c22-44ff-8591-fef184f4d2ab";
            AppCenter.Start($"android={androidAppSecret};ios={iOSAppSecret}", typeof(Crashes), typeof(Analytics));

            var didAppCrashed = await Crashes.HasCrashedInLastSessionAsync();

            if (didAppCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();
            }
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
