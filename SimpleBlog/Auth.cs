﻿using System.Linq;
using System.Net.Http;
using System.Web;
using Microsoft.SqlServer.Server;
using NHibernate.Linq;
using SimpleBlog.Models;

namespace SimpleBlog
{
    public static class Auth
    {
        private const string UserKey = "SimpleBlog.Auth.UserKey";

        public static User User
        {
            get
            {
                if(!HttpContext.Current.User.Identity.IsAuthenticated)
                    return null;

                var user = HttpContext.Current.Items[UserKey] as User;
                if (user == null)
                {
                    user = Database.Session.Query<User>()
                            .FirstOrDefault(u => u.Username == HttpContext.Current.User.Identity.Name);

                    if (user == null)
                        return null;

                    HttpContext.Current.Items[UserKey] = user;
                }

                return user;

            }
        }

    }
}