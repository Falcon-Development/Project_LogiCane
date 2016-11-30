/*
    Author      : Divyashree
    Modified by : Pooja Mohite
    Date        : 11/28/2016
    Description : This page is class obeject to patientvisit page.
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

namespace AndroidExpandableListView
{
    class PateintVisitListView: BaseAdapter<PatientVisitTextData>
    {
        private List<PatientVisitTextData> mitems;
        private Context mContext;
        public PateintVisitListView(Context context,List<PatientVisitTextData> items)
        {
            mitems = items;
            mContext = context;
        }
        public override PatientVisitTextData this[int position]
        {
            get
            {
                return mitems[position];
            }
        }

        public override int Count
        {
            get
            {
                return mitems.Count;
              
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // getting the row type from a layout file , where that layout acts as a row in our main layout
            View row = convertView;
            if (row==null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.PatientVisitTextList,null,false);
            }
            // Each Text field object of the layout is filled with row type
            TextView txtDate = row.FindViewById<TextView>(Resource.Id.txtDate);
            txtDate.Text = mitems[position].date;
            TextView txtPID = row.FindViewById<TextView>(Resource.Id.txtPID);
            txtPID.Text = mitems[position].vid;
            return row;
        }
    }
}