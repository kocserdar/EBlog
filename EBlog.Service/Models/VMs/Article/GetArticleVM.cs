﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs.Article
{
    public class GetArticleVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string AuthorFullName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
