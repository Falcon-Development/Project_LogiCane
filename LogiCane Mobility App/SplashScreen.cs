/*
    Author      : Jeff Bryant
    Modified by : Pooja Mohite
    Date        : 10/27/2016
    Description : This page launches the app with splashing of App LOGO and connects to signinactivity page.
*/
using Android.App;
using Android.OS;
using Android.Media;
using AndroidExpandableListView;

namespace SplashScreen
{
    [Activity(Theme         = "@style/Theme.Splash", 
              MainLauncher  = true, 
              NoHistory     = true)]

    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Play startup sound
            MediaPlayer mp = MediaPlayer.Create(this,Resource.Raw.Audio_SplashStartUp);
            mp.Start();

            // Sleep activity for two seconds
            System.Threading.Thread.Sleep(2000);

            // After activity sleep, create the main activity
            // Start the next page
            this.StartActivity(typeof(SignInActivity));
        }
    }
}