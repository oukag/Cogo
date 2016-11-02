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
        private string host;
        private string location;
        private string gmUrl;
        private List<CommentItem> comments;

        public EventModel()
        {
            this.id = null;
            this.name = "";
            this.description = "";
            this.date = new DateTime();
            this.tags = new List<string>();
            this.host = "";
            this.location = "";
            this.gmUrl = "";
            this.comments = new List<CommentItem>();
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

        public string getHost()
        {
            return this.host;
        }

        public void setHost(string host)
        {
            this.host = host;
        }

        public string getLocation()
        {
            return this.location;
        }

        public void setLocation(string location)
        {
            this.location = location;
        }

        public string getGoogleMapsUrl()
        {
            return this.gmUrl;
        }

        public void setGoogleMapsUrl(string gmUrl)
        {
            this.gmUrl = gmUrl;
        }

        public List<CommentItem> getComments()
        {
            return this.comments;
        }

        public void setComments(List<CommentItem> comments)
        {
            this.comments = comments;
        }
    }
}