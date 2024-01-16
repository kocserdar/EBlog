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


        public LikeServices(IUnitOfWorks unitOfWorks)
        {
            _unitOfWorks = unitOfWorks;

        }

        public async Task CreateLike(CreateLikeDTO model)
        {
            var like = _unitOfWorks.Mapper.Map<Like>(model);
            like.Status = Core.Enums.Status.Active;
            like.CreatedAt = DateTime.Now;
            await _unitOfWorks.LikeRepo.Create(like);
            //return Task.FromResult(like);
            //return Task.CompletedTask;
        }

        public async Task DeleteLike(int id)
        {
            var like = await _unitOfWorks.LikeRepo.GetById(id);
            like.Status = Core.Enums.Status.Passive;
            like.PassivedAt = DateTime.Now;
            _unitOfWorks.LikeRepo.Delete(like);
        }


    }
}
