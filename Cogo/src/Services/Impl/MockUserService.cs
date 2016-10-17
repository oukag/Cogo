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
    public class MockUserService : UserService
    {
        private IdGenerator idGenerator;
        private List<UserModel> users;

        public MockUserService()
        {
            idGenerator = new MockIdGenerator();
            users = new List<UserModel>();
        }

        public UserModel getUserForId(string id)
        {
            for (int i = 0; i < users.Count; i++)
            {
                UserModel user = users[i];
                if (user.getId().Equals(id))
                {
                    return user;
                }
            }
            return null;
        }

        public UserModel getUserForUsername(string username)
        {
            for (int i = 0; i < users.Count; i++)
            {
                UserModel user = users[i];
                if (user.getUsername().Equals(username))
                {
                    return user;
                }
            }
            return null;
        }

        public UserModel saveUser(UserModel user)
        {
            if (user.getId() != null)
            {
                int i = getIndexForUser(user);
                if (i >= 0)
                {
                    users[i] = user;
                }
                else
                {
                    users.Add(user);
                }
            }
            else
            {
                user.setId(idGenerator.getNextId());
                users.Add(user);
            }
            return user;
        }

        private int getIndexForUser(UserModel user)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].getId().Equals(user.getId()))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}