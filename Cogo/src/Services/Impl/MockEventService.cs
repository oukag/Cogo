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
                   // Removed parsing to a separate function because it was getting to complex to be mixed into this function
                   saveEvent(parseEvent(row));
                }
            }
            System.Diagnostics.Debug.WriteLine("Loaded {0} events from {1}", events.Count, FILENAME);
        }

        /**
         * Creates an eventModel from a CsvRow list of strings. It is assumed that the CsvRow follows the following order:
         * Title
         * Date
         * Location
         * Summary
         * Description
         * Host
         * Tags
         * Google Maps Url, if no Url is attached it will place a null value in its place in the EventModel
         */
        private EventModel parseEvent(CsvRow row)
        {
            // Converting the CsvRow list into more readable variable names
            string title       = (row.Count > 0) ? row[0] : null;
            string dateStr     = (row.Count > 1) ? row[1] : null;
            string location    = (row.Count > 2) ? row[2] : null;
            string summary     = (row.Count > 3) ? row[3] : null;
            string description = (row.Count > 4) ? row[4] : null;
            string company     = (row.Count > 5) ? row[5] : null;
            string tagStr      = (row.Count > 6) ? row[6] : null;
            string mapsUrl     = (row.Count > 7) ? row[7] : null;
            
            // Creating the base event model to store the information
            EventModel e = new Models.EventModel();
            // Populating the event model with the CSV information
            e.setName(title);
            e.setDescription(summary);
            e.setLocation(location);
            e.setHost(company);
            e.setGoogleMapsUrl(mapsUrl);

            DateTime date = new DateTime();
            DateTime.TryParseExact(dateStr, DATE_PATTERN, null, System.Globalization.DateTimeStyles.None, out date);
            e.setDate(date);

            List<string> tags = new List<string>();
            foreach(string s in tagStr.Split(','))
            {
                tags.Add(s);
            }
            e.setTags(tags);

            return e;
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