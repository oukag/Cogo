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
using Android.Content.Res;
using System.IO;
using ReadWriteCsv;

namespace Cogo.Services.Impl
{
    public class MockEventService : EventService
    {
        private IdGenerator idGenerator;
        private List<EventModel> events;
        private List<string> tags;

        private static string FILENAME = "Events.csv";
        private static string DATE_PATTERN = "M/dd/yyyy hh:mm a";

        public MockEventService(Context context)
        {
            idGenerator = new MockIdGenerator();
            events = new List<EventModel>();
            tags = new List<string>();
            initializeEvents(context);
        }

        private void initializeEvents(Context context)
        {
            System.Diagnostics.Debug.WriteLine("Initializing Events");
            AssetManager assets = context.Assets;
            using(CsvFileReader reader = new CsvFileReader(assets.Open(FILENAME)))
            {
                CsvRow row = new CsvRow();
                CsvRow fields = new CsvRow();
                reader.ReadRow(fields);
                foreach (string s in fields)
                {
                    System.Diagnostics.Debug.WriteLine(s);
                }
                while (reader.ReadRow(row))
                {
                    string name = row[0];
                    string summary = row[1];
                    string description = row[2];
                    List<string> tags = new List<string>();
                    foreach(string s in row[3].Split(','))
                    {
                        if(!tags.Contains(s))
                        {
                            tags.Add(s);
                        }
                        tags.Add(s);
                    }
                    string dateStr = row[4];
                    DateTime date;

                    DateTime.TryParseExact(dateStr, DATE_PATTERN, null, System.Globalization.DateTimeStyles.None, out date);

                    EventModel e = new EventModel();
                    e.setName(name);
                    e.setDescription(description);
                    e.setDate(date);
                    e.setTags(tags);
                    saveEvent(e);
                }
            }
            System.Diagnostics.Debug.WriteLine("Loaded {0} events from {1}", events.Count, FILENAME);
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
            if (e.getId() != null && e.getId() != "")
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

        public List<EventModel> getEventsForTag(string tag)
        {
            List<EventModel> result = new List<EventModel>();
            if(!tags.Contains(tag))
            {
                return result;
            }
            foreach(EventModel e in events)
            {
                foreach(string t in e.getTags())
                {
                    if(tag.Equals(t))
                    {
                        result.Add(e);
                    }
                }
            }
            return result;
        }
    }
}