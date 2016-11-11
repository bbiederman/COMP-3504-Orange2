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
using Android.Views.InputMethods;

namespace customer_client
{
    [Activity(Label = "Review Order")]
    public class OrderTableAct : Activity
    {

        private dataAccess data = dataAccess.getInstance();
        private ListView itemTable;
        private adapter stAdapter; // data adapter for stored items
        private EditText total;
        private Button dingbutton;
        //private EditText itemNameEditText;









        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.orderTable);
            //avoid automaticaly appear of android keyboard when activitry starts
            Window.SetSoftInputMode(SoftInput.StateHidden);

            // Create your application here
            //Intent theIntent = getIntent();
            //Bundle theBundle =


            //if(Intent.GetStringExtra("menuItemName" == null) 
            //{


            //var dialog = new AlertDialog.Builder(this);
            //dialog.SetTitle("Menu Info");
            //dialog.SetMessage(menuItemName);
            //dialog.Show();

            //Activity currActvity = currentActi
            //Activity currContext = CrossCurr

            loadViews();


            rando();

                
                
            

            
            //connectActions();

            


        }

        private void rando()
        {
            if (Intent.HasExtra("menuItemName"))
            {
                string menuItemName = Intent.GetStringExtra("menuItemName");
                //Intent.RemoveExtra("menuItemName");


                stAdapter = new adapter(this);
                itemTable.Adapter = stAdapter;
                itemTable.FastScrollEnabled = true;
                data.addItem(new menuItem(menuItemName));
                stAdapter.NotifyDataSetChanged();

                itemTable.ItemClick += itemTable_ItemClick;
                itemTable.ItemLongClick += itemTable_ItemLongClick;
            }
            }

        private void loadViews()
        {   //the list view with all data get from sqlite
            itemTable = FindViewById<ListView>(Resource.Id.orderTable);
            //button plays a sound
            dingbutton = FindViewById<Button>(Resource.Id.dingBut);
            //calc total from item price
            total = FindViewById<EditText>(Resource.Id.total);
        }






        //Will just display an alert of all the student info
        private void itemTable_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //var dialog1 = new AlertDialog.Builder(this);
            //dialog1.SetTitle("Delete menu item");
            //dialog1.SetMessage("ID is: ");
            //dialog1.Show();
            
            menuItem selectedSt = stAdapter[e.Position];

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Item Info");
            dialog.SetMessage(selectedSt.ID + " " + selectedSt.foodName);
            dialog.Show();
            
        }




        //Will ask if they want to remove the item
        private void itemTable_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            menuItem selectedSt = stAdapter[e.Position];
            //selectedSt.ID = 1;

            //var dialog1 = new AlertDialog.Builder(this);
            //dialog1.SetTitle("Delete menu item");
            //dialog1.SetMessage("ID is: ");
            //dialog1.Show();

            var dialog = new AlertDialog.Builder(this);
            dialog.SetTitle("Delete menu item");
            dialog.SetMessage(selectedSt.ID + " " + selectedSt.foodName);
            dialog.SetPositiveButton("Delete",
                (senderAlert, args) =>
                { // action for this button
                    data.deleteItemByID(selectedSt.ID);
                    stAdapter.NotifyDataSetChanged();
                    Toast.MakeText(this, "The menu item has been deleted", ToastLength.Short).Show();
                }
                );
            dialog.SetNegativeButton("cancel", (senderAlert, args) => { });

            dialog.Show();

            
        }


        //this hides the key board
        private void hideKeyBoard(Android.Views.View element)
        {
            InputMethodManager im = (InputMethodManager)GetSystemService(Context.InputMethodService);
            im.HideSoftInputFromWindow(element.WindowToken, 0);

        }





        //this method does the total sum of item ordered, incomplete
        private void itemTotal() {
             int tot = 0;

            //loop into sqlite and get menuItem prices




            total.Text = "your total is " + tot;


        }


        //press the button plays the sound and provides the total, incomplete 
        private void finish() {

            dingbutton.Click += delegate
            {


                //play sound

                //calculate the total



            };




        }









    }
}