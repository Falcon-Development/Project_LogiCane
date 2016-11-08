
using System.Collections.Generic;


using Android.App;
using Android.Content;
using Android.OS;
using AndroidExpandableListView;
using Android.Widget;
using Android.Support.V7.App;
using AndroidPatientVisitData;

namespace AndroidExpandableListView
{
    [Activity(Label = "PatientVisitInital",
                        MainLauncher = false,
                        Icon = "@drawable/icon",
                        Theme = "@style/MyTheme")]
    public class PatientVisitInital : AppCompatActivity
    {
        // Adapter creation for expandable list view of patients
        PatientView patientExListViewAdapter;
        ExpandableListView expandableListView;
        List<string> group = new List<string>();
        Dictionary<string, List<PatientVisitData>> map = new Dictionary<string, List<PatientVisitData>>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.PatientVisit);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Patient Visit Details";
            expandableListView = FindViewById<ExpandableListView>(Resource.Id.expandableListView);

            // Set Data
            SetData(out patientExListViewAdapter);
            expandableListView.SetAdapter(patientExListViewAdapter);

            // Popup text for patient selection verification
            expandableListView.ChildClick += (s, e) =>
            {
               /* var nextPage = new Intent(this, typeof(PatientStats));
                StartActivity(nextPage);
                //Toast.
                //MakeText(this, "You have selected " /* Patient Name */ 
                //  + patientExListViewAdapter.GetChild(e.GroupPosition, e.ChildPosition), ToastLength.Short).Show();
            };
        }

        private void SetData(out PatientView patientExListViewAdapter)
        {
            List<PatientVisitData> groupA = new List<PatientVisitData>();
            PatientVisitData PD = new PatientVisitData("Jan 1 2016","1");
            groupA.Add(PD);
           /* groupA.Add("Feb 1 2016");
            groupA.Add("March 5 2016");
            groupA.Add("April 6 2016");
            groupA.Add("May 1 2016");
            */

            group.Add("Dates Visited");
            map.Add(group[0], groupA);

            patientExListViewAdapter = new PatientView(this, group, map);
        }

    }
}