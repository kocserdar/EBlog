using EBlog.Core.Entities;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.Comment;
using EBlog.Service.Utilities.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.CommentServices
{
    public class CommentServices : ICommentServices
    {
        private readonly IUnitOfWorks _unitOfWorks;

        public CommentServices(IUnitOfWorks unitOfWorks)
        {

            _unitOfWorks = unitOfWorks;
        }

        public async Task CreateComment(CreateCommentDTO model)
        {
            var comment = _unitOfWorks.Mapper.Map<Comment>(model);
            comment.Status = Core.Enums.Status.Active;
            comment.CreatedAt = DateTime.Now;

            await _unitOfWorks.CommentRepo.Create(comment);
        }

        public Task DeleteComment(string id)
        {
            throw new NotImplementedException();
        }

    }
}
