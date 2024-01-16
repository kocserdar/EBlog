using EBlog.Service.Models.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.CommentServices
{
    public interface ICommentServices
    {
        Task CreateComment(CreateCommentDTO model);

        Task DeleteComment(string id);

    }
}
