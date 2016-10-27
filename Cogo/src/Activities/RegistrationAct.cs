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

namespace Cogo.Activities
{
    [Activity(Label = "RegistrationAct")]
    public class RegistrationAct : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RegistrationPage);

            Button SignInB2 = FindViewById<Button>(Resource.Id.SignInB2);
            SignInB2.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(LoginPageAct));
                StartActivity(intent);
            };
            Button RegisterB = FindViewById<Button>(Resource.Id.RegisterB);
            RegisterB.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(NewsFeedAct));
                StartActivity(intent);
            };

        }
    }
}