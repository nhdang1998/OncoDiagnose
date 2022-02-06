using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class DrugSynonymBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DrugSynonymBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<DrugSynonymViewModel>> GetAll()
        {
            var drugSynonyms = await _unitOfWork.DrugSynonym.GetDrugSynonymsAsync();
            return drugSynonyms.Any() ? _mapper.Map<List<DrugSynonymViewModel>>(drugSynonyms) : null;
        }

        public async Task<DrugSynonymViewModel> GetById(int? drugId, int? synonymId)
        {
            if (drugId == null && synonymId == null)
            {
                return null;
            }
            var drugSynonym = await _unitOfWork.DrugSynonym.GetDrugSynonymAsync(drugId.GetValueOrDefault(), synonymId.GetValueOrDefault());
            return drugSynonym == null ? null : _mapper.Map<DrugSynonymViewModel>(drugSynonym);
        }

        public IEnumerable<DrugViewModel> GetDrugs()
        {
            var drugs = _unitOfWork.DrugSynonym.GetDrugs();
            return drugs.Any() ? _mapper.Map<IEnumerable<DrugViewModel>>(drugs) : null;
        }

        public IEnumerable<SynonymViewModel> GetSynonyms()
        {
            var synonyms = _unitOfWork.DrugSynonym.GetSynonyms();
            return synonyms.Any() ? _mapper.Map<IEnumerable<SynonymViewModel>>(synonyms) : null;
        }

        //public async Task Delete(DrugSynonymViewModel drugSynonymViewModel)
        //{
        //    var drugSynonym = _mapper.Map<DrugSynonym>(drugSynonymViewModel);
        //    _unitOfWork.DrugSynonym.Remove(drugSynonym);
        //    await _unitOfWork.Save();
        //}

        public async Task Add(DrugSynonymViewModel drugSynonymViewModel)
        {
            var drugSynonym = _mapper.Map<DrugSynonym>(drugSynonymViewModel);
            _unitOfWork.DrugSynonym.Add(drugSynonym);
            await _unitOfWork.Save();
        }

        public async Task Update(DrugSynonymViewModel drugSynonymViewModel)
        {
            var drugSynonym = _mapper.Map<DrugSynonym>(drugSynonymViewModel);
            _unitOfWork.DrugSynonym.Update(drugSynonym);
            await _unitOfWork.Save();
        }
    }
}