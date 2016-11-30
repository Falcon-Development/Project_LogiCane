/*
    Author      : Jeff Bryant
    Modified by : Pooja Mohite
    Date        : 11/21/2016
    Description : This page displays lists of patient for the therapist
*/

using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Collections.Generic;
using AndroidExpandableListView;
using Android.Content;

namespace MobilityApp
{   // Label properties
    [Activity(Label =  "LogiCane Mobility App", 
                        MainLauncher    = false, 
                        Icon            = "@drawable/icon",
                        Theme = "@style/MyTheme.Base")]
    public class MainActivity : Activity
    {
        // Adapter creation for expandable list view of patients
        PatientViewAdapter patientExListViewAdapter;
        ExpandableListView expandableListView;
        // Create container of strings for group
        List<string> group = new List<string>();
        Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            // var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            // SetSupportActionBar(toolbar);
            // SupportActionBar.Title = "Patient Selection";
            expandableListView = FindViewById<ExpandableListView>(Resource.Id.expandableListView);

            // Set Data for the expandable list view
            SetData(out patientExListViewAdapter);
            expandableListView.SetAdapter(patientExListViewAdapter);

            // Popup text for patient selection verification
            expandableListView.ChildClick += (s, e) => 
            {
                var nextPage = new Intent(this, typeof(PatientVisit));
                StartActivity(nextPage);
                // Uncomment for pop-up user selection notification
                //Toast.
                //MakeText(this, "You have selected " /* Patient Name */ 
                //  + patientExListViewAdapter.GetChild(e.GroupPosition, e.ChildPosition), ToastLength.Short).Show();
            };
        }

        // Template reservation for mock-up patient list
        private void SetData(out PatientViewAdapter patientExListViewAdapter)
        {
            // Individual patients
            List<string> groupA = new List<string>();
            groupA.Add("Evan");
            groupA.Add("Pooja");
            groupA.Add("Div");
            groupA.Add("Max");
            groupA.Add("Jeff");

            // Add paitents to group "A"
            group.Add("Patients");
            map.Add(group[0], groupA);

            patientExListViewAdapter = new PatientViewAdapter(this, group, map);
        }
    }
}