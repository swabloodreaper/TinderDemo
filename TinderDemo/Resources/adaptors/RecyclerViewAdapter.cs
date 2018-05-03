using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace TinderDemo.Resources.adaptors
{
    internal class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<string> names;

        public RecyclerViewAdapter(List<string> names)
        {
            this.names = names;
            NotifyDataSetChanged();
        }
        public override int ItemCount
        {
            get
            {
                return names.Count;
            }
        }
        public class MyView : RecyclerView.ViewHolder
        {
            public View mainview
            {
                get;
                set;
            }
            public TextView Name
            {
                get;
                set;
            }
            public CheckBox IsChecked
            {
                get;
                set;
            }
            public MyView(View view) : base(view)
            {
                mainview = view;
            }
        }
        bool check =true;
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
              // throw new NotImplementedException();
            MyView myholder = holder as MyView;
            myholder.Name.Text = names[position];
            myholder.IsChecked.Checked = check;
            check = !check;
      
        }

        internal void UpdateListAdapter()
        {
            NotifyDataSetChanged();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View listItem = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerLayout,parent,false);
            var name = listItem.FindViewById<TextView>(Resource.Id.re_text);
            var checkbox = listItem.FindViewById<CheckBox>(Resource.Id.re_checkbox);
            MyView view = new MyView(listItem)
            {
                Name = name,IsChecked = checkbox
            };

            return view;
        }
    }
}