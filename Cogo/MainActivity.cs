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

namespace DesignerWalkthrough
{
    [Activity (Label = "Cogo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EventService eventService;
        UserService userService;

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);

            SetContentView (Resource.Layout.Login);

            initializeDatabase();
        }

        private void initializeDatabase()
        {
            userService = new MockUserService(this);
            eventService = new MockEventService(this);
        }
    }
}