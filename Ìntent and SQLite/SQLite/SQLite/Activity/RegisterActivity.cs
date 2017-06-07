using Android.App;
using Android.OS;
using Android.Widget;
using System;
using System.IO;

namespace SQLite
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        //Declare Controls
        EditText txtusername;
        EditText txtPassword;
        Button btncreate;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Setting the acivity 
            SetContentView(Resource.Layout.Newuser);


            //Assigned the controls
            btncreate = FindViewById<Button>(Resource.Id.btn_reg_create);
            txtusername = FindViewById<EditText>(Resource.Id.txt_reg_username);
            txtPassword = FindViewById<EditText>(Resource.Id.txt_reg_password);
            btncreate.Click += Btncreate_Click;
        }

        private void Btncreate_Click(object sender, EventArgs e)
        {

            try
            {
                //Connection String
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Telliantuser.db3");

                //Creating Connection
                var db = new SQLiteConnection(dpPath);

                //Creating Table
                db.CreateTable<Login>();

                //Accessing class file as class table
                Login tbl = new Login();
                tbl.username = txtusername.Text;
                tbl.password = txtPassword.Text;

                //Record Insertion through Login class
                db.Insert(tbl);

                //Message to End User
                Toast.MakeText(this, "Record Added Successfully...,", ToastLength.Short).Show();
            }
            catch (Exception ex)
            {
                //Error Message
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}