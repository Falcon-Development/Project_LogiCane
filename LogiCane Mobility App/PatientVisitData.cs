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

namespace AndroidPatientVisitData
{
    public class PatientVisitData
    {
        string date;
        string visitnum;
        public PatientVisitData(string d,string num)
        {
            date = d;
            visitnum =num ;
        }
        public string getPatientVisitData()
        {
            return date + " \t " + visitnum;
        }
    }
}