using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace HelloWorld
{
    [Activity(Label = "HelloWorld", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button clik;
        TextView label;
        static int i=0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            clik = FindViewById<Button>(Resource.Id.clickme);
            label = FindViewById<TextView>(Resource.Id.label);
            clik.Click += Clicked;
        }

        private void Clicked(object sender, EventArgs e)
        {
            i++;
            Toast.MakeText(this, i.ToString(), ToastLength.Short).Show();
            label.Text = i.ToString();   
        }
    }
}

