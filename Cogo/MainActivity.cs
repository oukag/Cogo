using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Cogo;
using Cogo.Services;
using Cogo.Services.Impl;
using Cogo.Models;
using Cogo.Adapters;

namespace DesignerWalkthrough
{
    [Activity(Label = "Cogo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        EventService eventService;
        UserService userService;
        List<CommentItem> Comments = new List<CommentItem>();
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            initializeDatabase();

            SetContentView(Resource.Layout.LoginPage);
            listView = FindViewById<ListView>(Resource.Id.listView1);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Cogo";


            Comments.Add(new CommentItem()
            {
                UserImage = Resource.Drawable.First,
                UserName = "Samantha Jennings",
                Comment = "FIRST!"
            });
            Comments.Add(new CommentItem()
            {
                UserImage = Resource.Drawable.two,
                UserName = "John Jacobs",
                Comment = "Excited to take my family to this!"
            });
            Comments.Add(new CommentItem()
            {
                UserImage = Resource.Drawable.third,
                UserName = "Amanda Flimmings",
                Comment = "What a great idea! Can't wait to enjoy the festivities"
            });

            listView.Adapter = new CommentAdapter(this, Comments);
        }


        private void initializeDatabase()
        {
            userService = new MockUserService(this);
            eventService = new MockEventService(this);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.toolbarmenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}
