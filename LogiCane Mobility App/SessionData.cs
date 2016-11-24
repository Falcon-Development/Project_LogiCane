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
using System.Collections;
using MikePhil.Charting.Data;
using MikePhil.Charting.Interfaces.Datasets;
using MikePhil.Charting.Components;
using Android.Graphics;

namespace AndroidExpandableListView
{
    [Activity(Label = "SessionData")]
    public class SessionData : Activity
    {
        LineChart lineChart;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SessionData);

            lineChart = (LineChart)FindViewById(Resource.Id.linechart);

            List<Entry> yVals = new List<Entry>();

            double j = 0;
            
            for (int i = 0; i < 1000; i++)
            {
             // float x1 = float.Parse((Math.Sin(x)).ToString());
                float y = float.Parse((Math.Sin(j).ToString()));
                j++;
                yVals.Add(new Entry(i,y));
            }
            LineDataSet sety = new LineDataSet(yVals, "yData");
            sety.SetDrawCircles(false);
            sety.SetMode(LineDataSet.Mode.CubicBezier);
            sety.SetDrawValues(false);
          //  sety.SetColor(0,0);
            LineData data = new LineData(sety);
            lineChart.Data=(data);
            lineChart.SetVisibleXRangeMaximum(65f);
            lineChart.SetBackgroundColor(Color.FloralWhite);
            lineChart.SetDrawGridBackground(false);
                       
            

              /*  JavaList<String> xAXES = new JavaList<string>();
                List<Entry> yAXESsin = new List<Entry>();
                List<Entry> yAXEScos = new List<Entry>();
                double x = 0;
                int numDataPoints = 1000;
                int i;
                for ( i=0;i<numDataPoints;i++)
                {
                    float sinFunction = float.Parse((Math.Sin(x)).ToString());
                    float cosFunction = float.Parse((Math.Cos(x)).ToString());
                    x += 1;
                    yAXESsin.Add(new Entry(sinFunction,i));
                    yAXEScos.Add(new Entry(cosFunction, i));
                    xAXES.Add(i,x.ToString());
                }
                String[] xaxes = new String[xAXES.Size()];
                for (i=0;i<xAXES.Size();i++)
                {
                    xaxes[i] = xAXES.Get(i).ToString();
                }

                List<ILineDataSet> lineDataSet = new List<ILineDataSet>();

                LineDataSet lineDataSet1 = new LineDataSet(yAXESsin,"Sin");
                lineDataSet1.SetDrawCircles(false);
                lineDataSet.Add(lineDataSet1);
                LineData data= new LineData(lineDataSet1);
                lineChart.Data = data;
                lineChart.SetVisibleXRangeMaximum(65f);


                */

            
        }
    }
}