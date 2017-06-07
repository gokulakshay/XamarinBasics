using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Widget;
using System;
using System.IO;

namespace SQLite
{
    [Activity(Label = "SQLite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        //Declare Controls
        EditText txtusername;
        EditText txtPassword;
        Button btncreate;
        Button btnsign;

        //Declaring SharedPrefernces
        ISharedPreferences prefs;
        ISharedPreferencesEditor editor;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Setting the acivity 
            SetContentView(Resource.Layout.Main);

            //Assigned the controls
            btnsign = FindViewById<Button>(Resource.Id.btnlogin);
            btncreate = FindViewById<Button>(Resource.Id.btnregister);
            txtusername = FindViewById<EditText>(Resource.Id.txtusername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtpwd);

            //Events
            btnsign.Click += Btnsign_Click;
            btncreate.Click += Btncreate_Click;

            //Retriving the Shared Prefernces
            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            editor = prefs.Edit();

            //Assigning and Validating
            int launched = prefs.GetInt("Launched", 0);
            if (launched.Equals(0))
                CreateDB();

        }

        private void Btncreate_Click(object sender, EventArgs e)
        {
            //Moving to Next Activity
            StartActivity(typeof(RegisterActivity));
        }

        private void Btnsign_Click(object sender, EventArgs e)
        {
            try
            {
                //Connection String
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Telliantuser.db3");

                //Creating Connection
                var db = new SQLiteConnection(dpPath);

                //Accessing Table
                var data = db.Table<Login>();

                //Conditional Retrival
                var data1 = data.Where(x => x.username == txtusername.Text && x.password == txtPassword.Text).FirstOrDefault();

                //Validation
                if (data1 != null)
                {
                    Toast.MakeText(this, "Login Success", ToastLength.Short).Show();

                }
                else
                {
                    Toast.MakeText(this, "Username or Password invalid", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                //Exception
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();

            }

        }
        public string CreateDB()
        {

            // Creating New SQL Lite DB
            var output = "";
            output += "Creating Databse if it doesnt exists";

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Telliantuser.db3");
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";

            //Assigning value to Shared Prefernces
            editor.PutInt("Launched", 1);
            editor.Apply();

            return output;
        }

    }
}

