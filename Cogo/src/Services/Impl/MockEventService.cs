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
    public class MockEventService : EventService
    {
        private IdGenerator idGenerator;
        private List<EventModel> events;

        private static string FILENAME = "";

        public MockEventService()
        {
            idGenerator = new MockIdGenerator();
            events = new List<EventModel>();
        }

        private void initialize()
        {

        }

        public EventModel getEventForId(string id)
        {
            for (int i = 0; i < events.Count; i++)
            {
                EventModel e = events[i];
                if (e.getId().Equals(id))
                {
                    return e;
                }
            }
            return null;
        }

        public EventModel saveEvent(EventModel e)
        {
            if (e.getId() != null)
            {
                int i = getIndexForEvent(e);
                if (i >= 0)
                {
                    events[i] = e;
                }
                else
                {
                    events.Add(e);
                }
            }
            else
            {
                e.setId(idGenerator.getNextId());
                events.Add(e);
            }
            return e;
        }

        private int getIndexForEvent(EventModel e)
        {
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].getId().Equals(e.getId()))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}