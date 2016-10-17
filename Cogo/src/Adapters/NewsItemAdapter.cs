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
using Java.Lang;

namespace Cogo.Adapters
{
    class NewsItemAdapter : BaseAdapter
    {
        Activity context;
        List<NewsItem>

        public NewsItemAdapter(Activity context)
        {
            this.context = context;
        }

        public override int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            throw new NotImplementedException();
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if  (view == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.NewsItem, null);
            }

            view.FindViewById<TextView>(Resource.Id.newsTime) = 
            view.FindViewById<TextView>(Resource.Id.newsName) = 
            view.FindViewById<TextView>(Resource.Id.newsDecription) =

            return view;
        }
    }
}