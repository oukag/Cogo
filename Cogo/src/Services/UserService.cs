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
    public interface UserService
    {
        UserModel getUserForId(string id);

        UserModel getUserForUsername(string username);

        UserModel saveUser(UserModel user);
    }
}