using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;


namespace AndroidExpandableListView
{
    [Activity(Label = "PatientVisit")]
    public class PatientVisit : Activity
    {
      //  int count = 1;
        private List<PatientVisitTextData> myitems;
        private ListView patientVisitList;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.PatientVisit);
            patientVisitList = FindViewById<ListView>(Resource.Id.patientVisitList);



            myitems = new List<PatientVisitTextData>();
            myitems.Add(new PatientVisitTextData() { date = "DATE", vid = "PATIENT ID" });
            myitems.Add(new PatientVisitTextData() { date = "11/11/2016", vid = "P1" });
            myitems.Add(new PatientVisitTextData() { date = "11/10/2016", vid = "P2" });
            myitems.Add(new PatientVisitTextData() { date = "11/12/2016", vid = "P3" });
            myitems.Add(new PatientVisitTextData() { date = "11/13/2016", vid = "P4" });
            myitems.Add(new PatientVisitTextData() { date = "11/15/2016", vid = "P5" });

            // ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, myitems);
            PateintVisitListView adapter = new PateintVisitListView(this, myitems);
            patientVisitList.Adapter = adapter;

            patientVisitList.ItemClick += patientVisitList_ItemClick;


        }

        private void patientVisitList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            StartActivity(typeof(SessionData));
        }
    }
}