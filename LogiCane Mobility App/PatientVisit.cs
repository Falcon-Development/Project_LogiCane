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

    public class PatientView : BaseExpandableListAdapter
    {
        private Context context;
        private List<string> listGroup;
        private Dictionary<string, List<PatientVisitData>> _1stChild;

        public PatientView(Context context, List<string> listGroup, Dictionary<string, List<PatientVisitData>> _1stChild)
        {
            this.context = context;
            this.listGroup = listGroup;
            this._1stChild = _1stChild;
        }

        public override int GroupCount
        { get { return listGroup.Count; } }

        public override bool HasStableIds
        { get { return false; } }

        public override long GetChildId(int groupPosition, int childPosition)
        { return childPosition; }

        public override Java.Lang.Object GetGroup(int groupPosition)
        { return listGroup[groupPosition]; }

        public override long GetGroupId(int groupPosition)
        { return groupPosition; }

        public override bool IsChildSelectable(int groupPosition, int childPosition)
        { return true; }

        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            var result = new List<PatientVisitData>();
            _1stChild.TryGetValue(listGroup[groupPosition], out result);
            return result[childPosition].getPatientVisitData();
        }

        public override int GetChildrenCount(int groupPosition)
        {
            var result = new List<PatientVisitData>();
            _1stChild.TryGetValue(listGroup[groupPosition], out result);
            return result.Count;
        }

        public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Resource.Layout.item_layout, null);
            }
            TextView textViewItem = convertView.FindViewById<TextView>(Resource.Id.item);
            string content = (string)GetChild(groupPosition, childPosition);
            textViewItem.Text = content;
            return convertView;
        }


        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            if (convertView == null)
            {
                LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
                convertView = inflater.Inflate(Resource.Layout.group_item, null);
            }
            string textGroup = (string)GetGroup(groupPosition);
            TextView textViewGroup = convertView.FindViewById<TextView>(Resource.Id.group);
            textViewGroup.Text = textGroup;
            return convertView;
        }
   }

}