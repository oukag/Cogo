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
    public class UserModel
    {
        private string id;
        private string username;
        private string password;
        private List<EventModel> events;

        public UserModel()
        {
            this.id = "";
            this.username = "";
            this.password = "";
            this.events = new List<EventModel>();
        }

        public string getId()
        {
            return this.id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public string getUsername()
        {
            return this.username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getPassword()
        {
            return this.password;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public List<EventModel> getEvents()
        {
            return this.events;
        }

        public void setEvents(List<EventModel> events)
        {
            this.events = events;
        }
    }
}