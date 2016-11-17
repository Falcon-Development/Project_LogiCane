using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidPatientVisitData;

namespace AndroidExpandableListView
{

    [Activity(Label = "Login")]
    public class Login : Activity
    {
        // var username;
        // EditText password;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            Button loginButton = (Button)FindViewById(Resource.Id.button1);
            loginButton.Click += tryLogin;



            SetContentView(Resource.Layout.LoginLayout);
        }
        void tryLogin(object sender, EventArgs e)
        {
            //flags for user type
            bool patientFlag = false, therapistFlag = false, adminFlag = false;

            //get username and password as string
            var username = (EditText)FindViewById(Resource.Id.usertxt);
            var password = (EditText)FindViewById(Resource.Id.pwdtxt);

            String u = username.Text.ToString();
            String p = password.Text.ToString();

            //login logic here
            /*
            bool loginFlag = false;
            if(loginFlag && patientFlag)
            {
                var nextPage = new Intent(this, typeof(PatientVisitData));
                StartActivity(nextPage);
            }
            else if (loginFlag && therapistFlag)
            {
                var nextPage = new Intent(this, typeof(PatientViewAdapter));
                StartActivity(nextPage);
            }
            else if (loginFlag && adminFlag)
            {
                var nextPage = new Intent(this, typeof(PatientViewAdapter));
                StartActivity(nextPage);
            }
            else
            {
                //alert incorrect user or password
                Toast.MakeText(this, "Incorrect Username Password Combination", ToastLength.Short).Show();
                
            }*/
        }
    }



}