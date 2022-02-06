using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class ArticleBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ArticleBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MutationViewModel> GetMutations()
        {
            var mutations = _unitOfWork.Article.GetMutations();
            return mutations.Any() ? _mapper.Map<IEnumerable<MutationViewModel>>(mutations) : null;
        }
        public async Task<List<ArticleViewModel>> GetAll()
        {
            var articles = await _unitOfWork.Article.GetArticlesAsync();
            return articles.Any() ? _mapper.Map<List<ArticleViewModel>>(articles) : null;
        }

        public async Task<ArticleViewModel> GetById(int id)
        {
            var article = await _unitOfWork.Article.GetArticleByIdAsync(id);
            return article == null ? null : _mapper.Map<ArticleViewModel>(article);
        }

        public async Task Delete(ArticleViewModel articleViewModel)
        {
            var article = _mapper.Map<Article>(articleViewModel);
            _unitOfWork.Article.Remove(article);
            await _unitOfWork.Save();
        }

        public async Task Add(ArticleViewModel articleViewModel)
        {
            var article = _mapper.Map<Article>(articleViewModel);
            _unitOfWork.Article.Add(article);
            await _unitOfWork.Save();
        }

        public async Task Update(ArticleViewModel articleViewModel)
        {
            var article = _mapper.Map<Article>(articleViewModel);
            _unitOfWork.Article.Update(article);
            await _unitOfWork.Save();
        }
    }
}