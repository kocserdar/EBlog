using EBlog.Service.Models.DTOs.Article;
using EBlog.Service.Models.VMs.Article;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBlog.Service.Services.ArticleServices
{
    public interface IArticleServices
    {
        Task Create(CreateArticleDTO model);
        
        void Update(EditArticleDTO model);

        Task Delete(int id);

        Task<List<GetArticleVM>> GetArticles();
        
        Task<GetArticleDetailVM> GetArticleDetail(int id);

        Task<EditArticleDTO> GetArticle(int id);
    }
}
