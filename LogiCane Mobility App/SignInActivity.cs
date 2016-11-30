/*
    Modified by : Max and Pooja Mohite
    Date        : 11/21/2016
    Description : This page helps in connecting to google and login into app using gmail credetials. It also displays three buttons - Signout, Disconnect 
                  and Move ahead. Depending on Patient/Therapist next page is displayed.
*/

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
using Android.Support.V7.App;
using Android.Gms.Common.Apis;
using Android.Gms.Plus;
using Android.Gms.Common;
using Android.Util;
using MobilityApp;

namespace AndroidExpandableListView
{
    [Activity(Label = "SignInActivity", Theme = "@style/ThemeOverlay.MyNoTitleActivity")]
    
    public class SignInActivity : AppCompatActivity, View.IOnClickListener,
        GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        const string TAG = "signInActivity";

        const int RC_SIGN_IN = 9001;

        const string KEY_IS_RESOLVING = "is_resolving";
        const string KEY_SHOULD_RESOLVE = "should_resolve";

        GoogleApiClient mGoogleApiClient;

        TextView mStatus;

        bool mIsResolving = false;

        bool mShouldResolve = false;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Layout .axml page is mapped here
            SetContentView(Resource.Layout.sign_layout);
           // che ks for saved instance
            if (savedInstanceState != null)
            {
                mIsResolving = savedInstanceState.GetBoolean(KEY_IS_RESOLVING);
                mShouldResolve = savedInstanceState.GetBoolean(KEY_SHOULD_RESOLVE);
            }
            // gets the references to layout elements
            FindViewById(Resource.Id.sign_in_button).SetOnClickListener(this);
            FindViewById(Resource.Id.sign_out_button).SetOnClickListener(this);
            FindViewById(Resource.Id.disconnect_button).SetOnClickListener(this);

            FindViewById<SignInButton>(Resource.Id.sign_in_button).SetSize(SignInButton.SizeWide);
            FindViewById(Resource.Id.sign_in_button).Enabled = false;

            mStatus = FindViewById<TextView>(Resource.Id.status);
            // setting up properties to connect to Google
            mGoogleApiClient = new GoogleApiClient.Builder(this)
                .AddConnectionCallbacks(this)
                .AddOnConnectionFailedListener(this)
                .AddApi(PlusClass.API)
                .AddScope(new Scope(Scopes.Profile))
                .Build();

            Button loginButton = (Button)FindViewById(Resource.Id.move_ahead);
            loginButton.Click += delegate {
                if (this.ApplicationContext==null)
                {
                    Toast.MakeText(this, "Incorrect Username Password Combination", ToastLength.Short).Show();
                }
                //Call API to evaluate a patient/therapist and get the isPatient value.
                //Get isPatient from the user
                //if (isPatient == 0)
                {
                    StartActivity(typeof(MainActivity));
                }
                //else
                {
                //    StartActivity(typeof(PatientVisit));
                }
            }; 

        }
      
        void UpdateUI(bool isSignedIn)
        {// updating the styles of UI according to user's status, siged in or not
            if (isSignedIn)
            {
                var person = PlusClass.PeopleApi.GetCurrentPerson(mGoogleApiClient);
                //PlusClass.AccountApi.GetAccountName(mGoogleApiClient);
                var name = string.Empty;
                var email = string.Empty;
                if (person != null)
                {
                    name = person.DisplayName;
                    email = PlusClass.AccountApi.GetAccountName(mGoogleApiClient); 
                }
                mStatus.Text = string.Format(GetString(Resource.String.signed_in_fmt), name);
                // changing the visibility of some of the layout objects that were hidden as user was not signed in
                FindViewById(Resource.Id.sign_in_button).Visibility = ViewStates.Gone;
                FindViewById(Resource.Id.sign_out_and_disconnect).Visibility = ViewStates.Visible;
                FindViewById(Resource.Id.moveinout).Visibility = ViewStates.Visible;
                FindViewById(Resource.Id.move_ahead).Visibility = ViewStates.Visible;
                // API .. check if patient or therapist (gettype(emailid))
                               
            }
            else {
                mStatus.Text = GetString(Resource.String.signed_out);

                FindViewById(Resource.Id.sign_in_button).Enabled = true;
                FindViewById(Resource.Id.sign_in_button).Visibility = ViewStates.Visible;
                FindViewById(Resource.Id.sign_out_and_disconnect).Visibility = ViewStates.Gone;
                FindViewById(Resource.Id.moveinout).Visibility = ViewStates.Gone;
            }
        }

        protected override void OnStart()
        {// this method is called on every start 
            base.OnStart();
            mGoogleApiClient.Connect();
        }

        protected override void OnStop()
        {
            base.OnStop();
            mGoogleApiClient.Disconnect();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutBoolean(KEY_IS_RESOLVING, mIsResolving);
            outState.PutBoolean(KEY_SHOULD_RESOLVE, mIsResolving);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            Log.Debug(TAG, "onActivityResult:" + requestCode + ":" + resultCode + ":" + data);

            if (requestCode == RC_SIGN_IN)
            {
                if (resultCode != Result.Ok)
                {
                    mShouldResolve = false;
                }
                mIsResolving = false;
                mGoogleApiClient.Connect();
            }
        }

        public void OnConnected(Bundle connectionHint)
        {
            Log.Debug(TAG, "onConnected:" + connectionHint);
           
            UpdateUI(true);
        }

        public void OnConnectionSuspended(int cause)
        {
            Log.Warn(TAG, "onConnectionSuspended:" + cause);
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            Log.Debug(TAG, "onConnectionFailed:" + result);

            if (!mIsResolving && mShouldResolve)
            {
                if (result.HasResolution)
                {
                    try
                    {
                        result.StartResolutionForResult(this, RC_SIGN_IN);
                        mIsResolving = true;
                    }
                    catch (IntentSender.SendIntentException e)
                    {
                        Log.Error(TAG, "Could not resolve ConnectionResult.", e);
                        mIsResolving = false;
                        mGoogleApiClient.Connect();
                    }
                }
                else {
                    ShowErrorDialog(result);
                }
            }
            else {
                UpdateUI(false);
            }
        }

        class DialogInterfaceOnCancelListener : Java.Lang.Object, IDialogInterfaceOnCancelListener
        {
            public Action<IDialogInterface> OnCancelImpl { get; set; }

            public void OnCancel(IDialogInterface dialog)
            {
                OnCancelImpl(dialog);
            }
        }

        void ShowErrorDialog(ConnectionResult connectionResult)
        {
            int errorCode = connectionResult.ErrorCode;

            if (GooglePlayServicesUtil.IsUserRecoverableError(errorCode))
            {
                var listener = new DialogInterfaceOnCancelListener();
                listener.OnCancelImpl = (dialog) => {
                    mShouldResolve = false;
                    UpdateUI(false);
                };
                GooglePlayServicesUtil.GetErrorDialog(errorCode, this, RC_SIGN_IN, listener).Show();
            }
            else {
                var errorstring = string.Format(GetString(Resource.String.play_services_error_fmt), errorCode);
                Toast.MakeText(this, errorstring, ToastLength.Short).Show();

                mShouldResolve = false;
                UpdateUI(false);
            }
        }

        public async void OnClick(View v)
        {
            // evernt hander for each of button SignIn SignOut and Disconnect
            switch (v.Id)
            {
                case Resource.Id.sign_in_button:
                    mStatus.Text = GetString(Resource.String.signing_in);
                    mShouldResolve = true;
                    mGoogleApiClient.Connect();
                    break;
                case Resource.Id.sign_out_button:
                    if (mGoogleApiClient.IsConnected)
                    {
                        PlusClass.AccountApi.ClearDefaultAccount(mGoogleApiClient);
                        mGoogleApiClient.Disconnect();
                    }
                    UpdateUI(false);
                    break;
                case Resource.Id.disconnect_button:
                    if (mGoogleApiClient.IsConnected)
                    {
                         PlusClass.AccountApi.ClearDefaultAccount(mGoogleApiClient);
                         await PlusClass.AccountApi.RevokeAccessAndDisconnect(mGoogleApiClient);
                         mGoogleApiClient.Disconnect();
                         
                     }
                     UpdateUI(false);
                    break;
            }
        }
    }
}