using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;
/*using Android.Runtime;
using Android.Views;*/

namespace Testing_Blank_App
{
    [Activity(Label = "Logi Cane", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            // SetContentView (Resource.Layout.Main);

            EditText userName = FindViewById<EditText>(Resource.Id.unametxt);
            EditText pass = FindViewById<EditText>(Resource.Id.passtxt);
            Button authenticatebtn = FindViewById<Button>(Resource.Id.loginbtn);

            
            authenticatebtn.Click += (object sender, EventArgs e) =>
            {

                if (core.authenticateUser.checkForUser(userName.Text.ToString(), pass.Text.ToString()) == 1)
                {
                    var nextPage = new Intent(this, typeof(PatientList));
                    StartActivity(nextPage);
                }
                else {
                    var welcomeDialog = new AlertDialog.Builder(this);
                    welcomeDialog.SetMessage("User does not exsist Please register");
                    welcomeDialog.SetNegativeButton("OK", delegate { });
                    welcomeDialog.Show();
                }
             
            };
        }
    }
}

 