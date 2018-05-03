using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using TinderDemo.Resources.adaptors;

namespace TinderDemo.Resources.Activities
{
    [Activity(Label = "RecyclerViewDemoActivity")]
    public class RecyclerViewDemoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.RecyclerViewDemo);
            var recycler = FindViewById<RecyclerView>(Resource.Id.recyclerView1);
        List<string> Names = Enumerable.Range(0, 1000).Select(x => "Hello " + (x + 1)).ToList();
            RecyclerViewAdapter adapter = new RecyclerViewAdapter(Names);
            recycler.SetAdapter(adapter);
          var  recyclerview_layoutmanger = new LinearLayoutManager(this, LinearLayoutManager.Vertical, true);
            recycler.SetLayoutManager(recyclerview_layoutmanger);
          var refreshList = FindViewById<SwipeRefreshLayout>(Resource.Id.re_swipe);
            refreshList.Refresh += delegate
            {

                adapter.UpdateListAdapter();

                refreshList.Refreshing = false;


            };

        }
    }
}