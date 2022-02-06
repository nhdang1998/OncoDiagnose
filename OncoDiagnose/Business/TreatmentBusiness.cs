using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class TreatmentBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TreatmentBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<MutationViewModel> GetMutations()
        {
            var mutations = _unitOfWork.Article.GetMutations();
            return mutations.Any() ? _mapper.Map<IEnumerable<MutationViewModel>>(mutations) : null;
        }
        public async Task<List<TreatmentViewModel>> GetAll()
        {
            var treatments = await _unitOfWork.Treatment.GetTreatmentsAsync();
            return treatments.Any() ? _mapper.Map<List<TreatmentViewModel>>(treatments) : null;
        }

        public async Task<TreatmentViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var treatment = await _unitOfWork.Treatment.GetTreatmentByIdAsync(id.GetValueOrDefault());
            return treatment == null ? null : _mapper.Map<TreatmentViewModel>(treatment);
        }

        public async Task Delete(TreatmentViewModel treatmentViewModel)
        {
            var treatment = _mapper.Map<Treatment>(treatmentViewModel);
            _unitOfWork.Treatment.Remove(treatment);
            await _unitOfWork.Save();
        }

        public async Task Add(TreatmentViewModel treatmentViewModel)
        {
            var Treatment = _mapper.Map<Treatment>(treatmentViewModel);
            _unitOfWork.Treatment.Add(Treatment);
            await _unitOfWork.Save();
        }

        public async Task Update(TreatmentViewModel TreatmentViewModel)
        {
            var Treatment = _mapper.Map<Treatment>(TreatmentViewModel);
            _unitOfWork.Treatment.Update(Treatment);
            await _unitOfWork.Save();
        }
    }
}