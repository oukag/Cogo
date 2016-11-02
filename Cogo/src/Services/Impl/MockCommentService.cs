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
using Cogo.Models;

namespace Cogo.Services.Impl
{
    class MockCommentService : CommentService
    {
        public EventModel addCommentToEvent(EventModel eventModel, CommentItem comment)
        {
            throw new NotImplementedException();
        }

        public EventModel editCommentForEvent(EventModel eventModel, CommentItem comment)
        {
            throw new NotImplementedException();
        }
    }
}