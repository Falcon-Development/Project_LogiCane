/*
    Author      : Divyashree
    Modified by : Pooja Mohite
    Date        : 11/21/2016
    Description : This page creates graph for user activity on particular day.
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
using MikePhil.Charting.Charts;
using MikePhil.Charting.Data;
using Android.Graphics;

namespace AndroidExpandableListView
{
    [Activity(Label = "SessionData",
                        MainLauncher = false,
                        Icon = "@drawable/icon",
                         Theme = "@style/MyTheme.Base")]
    public class SessionData : Activity
    {
        //MPAndroid Chart library have class called as Line Chart 
        // Instance Instantiated
        LineChart lineChart;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SessionData);
            
            // Layout have a object in which the chart will be displayed             
            // Referencing that object
            lineChart = (LineChart)FindViewById(Resource.Id.linechart);

            List<Entry> yVals = new List<Entry>();

            double j = 0;

            for (int i = 0; i < 1000; i++)
            {
                // float x1 = float.Parse((Math.Sin(x)).ToString());
                float y = float.Parse((Math.Sin(j).ToString()));
                j++;
                yVals.Add(new Entry(i, y));
            }
            // Data for Ine Chart is set 
            LineDataSet sety = new LineDataSet(yVals, "yData");
            // Enables chart to be clear
            sety.SetDrawCircles(false);
            // Displays scrollable chart
            sety.SetMode(LineDataSet.Mode.CubicBezier);
            // hides the x and y values for each point
            sety.SetDrawValues(false);
            LineData data = new LineData(sety);
            lineChart.Data = (data);
            lineChart.SetVisibleXRangeMaximum(65f);
            // Sets the background color
            lineChart.SetBackgroundColor(Color.FloralWhite);
            // Grid lines are made invisible
            lineChart.SetDrawGridBackground(false);
        }
    }
}