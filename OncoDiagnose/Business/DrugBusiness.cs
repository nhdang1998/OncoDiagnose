using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class DrugBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DrugBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SynonymViewModel> GetSynonyms()
        {
            var synonyms = _unitOfWork.Drug.GetSynonyms();
            return synonyms.Any() ? _mapper.Map<IEnumerable<SynonymViewModel>>(synonyms) : null;
        }

        public IEnumerable<TreatmentViewModel> GetTreatments()
        {
            var treatments = _unitOfWork.Drug.GetTreatments();
            return treatments.Any() ? _mapper.Map<IEnumerable<TreatmentViewModel>>(treatments) : null;
        }

        public async Task<List<DrugViewModel>> GetAll()
        {
            var drugs = await _unitOfWork.Drug.GetDrugsAsync();
            return drugs.Any() ? _mapper.Map<List<DrugViewModel>>(drugs) : null;
        }

        public async Task<DrugViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var drug = await _unitOfWork.Drug.GetDrugByIdAsync(id.GetValueOrDefault());
            return drug == null ? null : _mapper.Map<DrugViewModel>(drug);
        }

        public async Task Delete(DrugViewModel drugViewModel)
        {
            var drug = _mapper.Map<Drug>(drugViewModel);
            _unitOfWork.Drug.Remove(drug);
            await _unitOfWork.Save();
        }

        public async Task Add(DrugViewModel drugViewModel)
        {
            var Drug = _mapper.Map<Drug>(drugViewModel);
            _unitOfWork.Drug.Add(Drug);
            await _unitOfWork.Save();
        }

        public async Task Update(DrugViewModel drugViewModel)
        {
            var drug = _mapper.Map<Drug>(drugViewModel);
            _unitOfWork.Drug.Update(drug);
            await _unitOfWork.Save();
        }
    }
}