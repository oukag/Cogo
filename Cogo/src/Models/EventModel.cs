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
    public class EventModel
    {
        private string id;
        private string name;
        private string description;
        private DateTime date;
        private List<string> tags;

        public EventModel()
        {
            this.id = "";
            this.name = "";
            this.description = "";
            this.date = new DateTime();
            this.tags = new List<string>();
        }

        public String getId()
        {
            return this.id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getDescription()
        {
            return this.description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

        public DateTime getDate()
        {
            return this.date;
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public List<string> getTags()
        {
            return this.tags;
        }

        public void setTags(List<string> tags)
        {
            this.tags = tags;
        }
    }
}