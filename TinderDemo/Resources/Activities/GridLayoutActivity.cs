using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.View.Menu;
using Android.Views;
using Android.Widget;

namespace TinderDemo.Resources.Activities
{
    [Activity(Label = "GridLayoutActivity", Theme = "@style/Theme.AppCompat", MainLauncher = true)]
    public class GridLayoutActivity : Activity,MenuBuilder.ICallback
    {
        Button button ;

        string[] language = { "C", "C++", "Java", ".NET", "iPhone", "Android", "ASP.NET", "PHP" };

        public bool OnMenuItemSelected(MenuBuilder p0, IMenuItem p1)
        {
            string tt = p1.TitleFormatted.ToString();
            switch (tt)
            {
                case "Email": button.Text = "Email";
                    break;
                case "Key": button.Text = "Key";
                    break;
                case "Place": button.Text = "Place";
                    break;
                default: button.Text = "Hello";
                    break;
            }
            return true;
        }

        public void OnMenuModeChange(MenuBuilder p0)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.GridLayoutDemo);

            button = FindViewById<Button>(Resource.Id.btnShow);
            button.Click += Button_Click;

            var autocmplt = FindViewById<AutoCompleteTextView>(Resource.Id.grid_autoTextView);
            ArrayAdapter arrayAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SelectDialogItem, language);
            autocmplt.Threshold = 1;
            autocmplt.Adapter = arrayAdapter;
            autocmplt.SetTextColor(Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.Red));
                }

        private void Button_Click(object sender, EventArgs e)
        {
            var v = sender as View;
            PopupMenu popup = new PopupMenu(this,v);
            MenuBuilder menuBuilder = new MenuBuilder(this);
            MenuInflater inflater = new MenuInflater(this);
            inflater.Inflate(Resource.Menu.PopupMenu, menuBuilder);
            MenuPopupHelper menuPopupHelper = new MenuPopupHelper(this, menuBuilder, v);
            popup.MenuItemClick += Popup_MenuItemClick;
            menuPopupHelper.SetForceShowIcon(true);
      
            menuPopupHelper.Show();
            menuBuilder.SetCallback(this);

            


        }
        private void Popup_MenuItemClick(object sender, PopupMenu.MenuItemClickEventArgs e)
        {
            var tt = sender as Menu;
         
            
        }
    }
}