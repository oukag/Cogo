using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Cogo.Models;
using Java.Lang;

namespace Cogo.Adapters
{
    class NewsItemAdapter : BaseAdapter<NewsItem>
    {
        List<NewsItem> items;
        Activity context;


        public NewsItemAdapter(Activity context, List<NewsItem> items)
             : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override NewsItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CommentItem, null);
            //view.FindViewById<TextView>(Resource.Id.newsTime) = 
            //view.FindViewById<TextView>(Resource.Id.newsName) = 
            //view.FindViewById<TextView>(Resource.Id.newsDecription) =
            //view.FindViewById<ImageView>(Resource.Id.ProfileImage).SetImageResource(item.UserImage);

            return view;
        }



    }
}