﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Models;
using SimpleBlog.ViewModels;
using NHibernate.Linq;

namespace SimpleBlog.Controllers
{
    public class LayoutController : Controller
    {       
        [ChildActionOnly]
        public ActionResult Sidebar()
        {
            return View(new LayoutSidebar
            {
                IsLoggedIn = Auth.User != null,
                UserName = Auth.User != null ? Auth.User.Username : "",
                IsAdmin = User.IsInRole("admin"),
                Tags = Database.Session.Query<Tag>().Select(tag => new 
                {
                    tag.Id,
                    tag.Name,
                    tag.Slug,
                    PostCount = tag.Posts.Count
                }).Where(t => t.PostCount > 0).OrderByDescending(p => p.PostCount)
                .Select(tag => new SidebarTag(tag.Id, tag.Name, tag.Slug, tag.PostCount)).ToList()
            });
        }
    }
}