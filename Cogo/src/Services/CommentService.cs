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

namespace Cogo.Services
{
    interface CommentService
    {
        EventModel addCommentToEvent(EventModel eventModel, CommentItem comment);

        EventModel editCommentForEvent(EventModel eventModel, CommentItem comment);
    }
}