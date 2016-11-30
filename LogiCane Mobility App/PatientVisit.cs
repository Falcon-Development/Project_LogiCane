/*
    Author      : Pooja Mohite
    Modified by : Divyashree
    Date        : 11/21/2016
    Description : This page displays list of particular patient visited date and his ID.
*/

using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;


namespace AndroidExpandableListView
{
    [Activity(Label = "PatientVisit",
                        MainLauncher = false,
                        Icon = "@drawable/icon",
                         Theme = "@style/MyTheme.Base")]
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
            // Refering to the object 
            patientVisitList = FindViewById<ListView>(Resource.Id.patientVisitList);

            // Pushing the data into List
            myitems = new List<PatientVisitTextData>();
            myitems.Add(new PatientVisitTextData() { date = "DATE", vid = "PATIENT ID" });
            myitems.Add(new PatientVisitTextData() { date = "11/11/2016", vid = "P1" });
            myitems.Add(new PatientVisitTextData() { date = "11/10/2016", vid = "P1" });
            myitems.Add(new PatientVisitTextData() { date = "11/12/2016", vid = "P1" });
            myitems.Add(new PatientVisitTextData() { date = "11/13/2016", vid = "P1" });
            myitems.Add(new PatientVisitTextData() { date = "11/15/2016", vid = "P1" });

           // Adapter to put down all items into the list
            PateintVisitListView adapter = new PateintVisitListView(this, myitems);
            patientVisitList.Adapter = adapter;
            // Items in List click event 
            patientVisitList.ItemClick += patientVisitList_ItemClick;
        }

          private void patientVisitList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
          {
            // Strats the next page which is a .cs file as a action of a button click event
              StartActivity(typeof(SessionData));
          }
          // Code that did not work for getting the data from local database.
       /* private async void patientVisitList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    //client.Timeout = new TimeSpan(0, 0, 10);
                    Uri url = new Uri("http://localhost:3000/api/marco");
                    var sendContent = new StringContent("");

                    using (HttpResponseMessage response = await client.PostAsync(url.ToString(), sendContent))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            // return MakeError("Bad status: " + response.StatusCode.ToString());
                        }


                        using (HttpContent content = response.Content)
                        {
                            string str = await content.ReadAsStringAsync();
                            if (str == null)
                            {
                                // return MakeError("Got null answer");
                            }


                            // App.Log("Response: " + str);
                            // return str;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                // App.Log("There is something bad with request: " + serialized + " the error was " + e.Message + " url = " + url.ToString());

                Console.WriteLine(err.Message);
                //  return MakeError("Timed out");
            }
        }*/
    }
}