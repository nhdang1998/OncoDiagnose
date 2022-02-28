using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class SynonymBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SynonymBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SynonymViewModel>> GetAll()
        {
            var synonyms = await _unitOfWork.Synonym.GetSynonymsAsync();
            return synonyms.Any() ? _mapper.Map<List<SynonymViewModel>>(synonyms) : null;
        }

        public async Task<SynonymViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var synonym = await _unitOfWork.Synonym.GetSynonymByIdAsync(id.GetValueOrDefault());
            return synonym == null ? null : _mapper.Map<SynonymViewModel>(synonym);
        }

        public async Task Delete(SynonymViewModel synonymViewModel)
        {
            var synonym = _mapper.Map<Synonym>(synonymViewModel);
            _unitOfWork.Synonym.Remove(synonym);
            await _unitOfWork.Save();
        }

        public async Task Add(SynonymViewModel synonymViewModel)
        {
            var synonym = _mapper.Map<Synonym>(synonymViewModel);
            _unitOfWork.Synonym.Add(synonym);
            await _unitOfWork.Save();
        }

        public async Task Update(SynonymViewModel synonymViewModel)
        {
            var synonym = _mapper.Map<Synonym>(synonymViewModel);
            _unitOfWork.Synonym.Update(synonym);
            await _unitOfWork.Save();
        }
    }
}