using EBlog.Core.Entities;
using EBlog.Repo.Interfaces;
using EBlog.Service.Models.DTOs.Like;
using EBlog.Service.Models.VMs.Article;
using EBlog.Service.Utilities.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.LikeServices
{
    public class LikeServices : ILikeServices
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly ILikeRepo _likeRepo;

        public LikeServices(IUnitOfWorks unitOfWorks, ILikeRepo likeRepo)
        {
            _unitOfWorks = unitOfWorks;
            _likeRepo = likeRepo;
        }

        public async Task CreateLike(CreateLikeDTO model)
        {
            var like = _unitOfWorks.Mapper.Map<Like>(model);
            like.Status = Core.Enums.Status.Active;
            like.CreatedAt = DateTime.Now;
            await _likeRepo.Create(like);
            //return Task.FromResult(like);
            //return Task.CompletedTask;
        }

        public async Task DeleteLike(int id)
        {
            var like = await _likeRepo.GetById(id);
            like.Status = Core.Enums.Status.Passive;
            like.PassivedAt = DateTime.Now;
            _likeRepo.Delete(like);
        }


    }
}
