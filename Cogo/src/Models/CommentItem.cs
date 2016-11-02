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

namespace Cogo.Models
{
    public class CommentItem
    {
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int UserImage { get; set; }

        // Intended to be for unique identifiers, need to decide if this is better than just creating a pid field.
        public DateTime Date { get; set; }
        public string EventId { get; set; }
              
    }
}
