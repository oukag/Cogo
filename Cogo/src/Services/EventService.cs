﻿using System;
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
    public interface EventService
    {
        EventModel getEventForId(string id);

        EventModel saveEvent(EventModel e);

        List<EventModel> getEventsForTag(string tag);

        EventModel addCommentToEvent(EventModel e, CommentItem c);

        EventModel editCommentForEvent(EventModel e, CommentItem c);
    }
}