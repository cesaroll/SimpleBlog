﻿using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;
using SimpleBlog.Infrastructure;
using SimpleBlog.Models;
using System.Collections.Generic;

namespace SimpleBlog.Areas.Admin.ViewModels
{
    public class TagCheckBox
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }

    public class PostsIndex
    {
        public PagedData<Post> Posts { get; set; }
    }

    public class PostsForm
    {
        public bool IsNew { get; set; }
        public int? PostId { get; set; }

        [Required, MaxLength(128)]
        public string Title { get; set; }
        [Required, MaxLength(128)]
        public string Slug { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public IList<TagCheckBox> Tags { get; set; }
    }
}