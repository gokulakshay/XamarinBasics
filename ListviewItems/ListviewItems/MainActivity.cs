using Android.App;
using Android.OS;
using Android.Util;
using Android.Widget;
using System.Collections.Generic;

namespace ListviewItems
{
    [Activity(Label = "ListviewItems", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        private ListView listnames;
        private List<string> itemlist;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            listnames = FindViewById<ListView>(Resource.Id.listView1);

            Log.Info("testTag", "before start adapter");

            itemlist = new List<string>();
            itemlist.Add("George Clooney");
            itemlist.Add("Alexandra Daddario");
            itemlist.Add("Chris Pratt");
            itemlist.Add("Robert Downey");
            itemlist.Add("Will Smith");
            itemlist.Add("Aleshia");
            itemlist.Add("Justin Timberlake");
            itemlist.Add("Marshal Mathers");
            itemlist.Add("Gal Gadot");
            itemlist.Add("Chris Hemsworth");
            itemlist.Add("Christian Bale");
            itemlist.Add("Ben Afflek");
            itemlist.Add("Chandler Bing");

            ArrayAdapter<string> adapter 
                = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, itemlist);

            Log.Info("testTag", "after start adapter");

            listnames.Adapter = adapter;

            Log.Info("testTag", "set adapter");
            listnames.ItemClick += Listnames_ItemClick;
        }

        private void Listnames_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, itemlist[e.Position], ToastLength.Short).Show();
        }

    }
}

