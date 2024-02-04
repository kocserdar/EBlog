using EBlog.Service.Models.VMs.Comment;
using EBlog.Service.Models.VMs.Like;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Models.VMs.Article
{
    public class GetArticleDetailVM
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string AuthorFullName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public bool? IsLiked { get; set; }
        public bool? IsMine { get; set; }

        public string AppUserId { get; set; }

        public List<GetCommentVM>? CommentList { get; set; }

        public List<GetLikeVM>? LikeList { get; set; }

        public string Slug { get; set; }
    }
}
