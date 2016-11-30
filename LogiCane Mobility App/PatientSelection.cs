/*
    Author      : Jeff Bryant
    Modified by : Divyashree
    Date        : 11/28/2016
    Description : This class is included as object for listview in Patientselection page.
*/

using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;

namespace AndroidExpandableListView
{
    // Create patient view adapter
    public class PatientViewAdapter : BaseExpandableListAdapter
    {
        // Variables for view adapter
        private Context context;
        private List<string> listGroup;
        private Dictionary<string, List<string>> _1stChild;

        // Set context/listGroup/_1stChild
        public PatientViewAdapter(Context context,List<string> listGroup,Dictionary<string,List<string>> _1stChild)
        {
            this.context    = context;
            this.listGroup  = listGroup;
            this._1stChild  = _1stChild;
        }

        // Method to return group count
        public override int GroupCount
        { get { return listGroup.Count; } }

        // Method to check for ID's
        public override bool HasStableIds
        { get { return false; } }

        // Method to return child position
        public override long GetChildId(int groupPosition, int childPosition)
        { return childPosition; }

        // Java method to return group position
        public override Java.Lang.Object GetGroup(int groupPosition)
        { return listGroup[groupPosition]; }

        // Method to return group position
        public override long GetGroupId(int groupPosition)
        { return groupPosition; }

        // Method to check if the child is selectable
        public override bool IsChildSelectable(int groupPosition, int childPosition)
        { return true; }

        // Java method for returning child position
        public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            var result = new List<string>();
            _1stChild.TryGetValue(listGroup[groupPosition], out result);
            return result[childPosition];
        }

        // Method to return children count
        public override int GetChildrenCount(int groupPosition)
        {
            var result = new List<string>();
            _1stChild.TryGetValue(listGroup[groupPosition], out result);
            return result.Count;
        }

        // Method to retern convert view
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

        // Method to get group view and retern
        public override View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
           if(convertView == null)
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