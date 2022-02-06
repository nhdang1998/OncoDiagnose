using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class CancerTypeBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CancerTypeBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<MutationViewModel> GetMutations()
        {
            var mutations = _unitOfWork.Article.GetMutations();
            return mutations.Any() ? _mapper.Map<IEnumerable<MutationViewModel>>(mutations) : null;
        }
        public async Task<List<CancerTypeViewModel>> GetAll()
        {
            var cancerTypes = await _unitOfWork.CancerType.GetCancerTypesAsync();
            return cancerTypes.Any() ? _mapper.Map<List<CancerTypeViewModel>>(cancerTypes) : null;
        }

        public async Task<CancerTypeViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var cancerType = await _unitOfWork.CancerType.GetCancerTypeByIdAsync(id.GetValueOrDefault());
            return cancerType == null ? null : _mapper.Map<CancerTypeViewModel>(cancerType);
        }

        public async Task Delete(CancerTypeViewModel cancerTypeViewModel)
        {
            var cancerType = _mapper.Map<CancerType>(cancerTypeViewModel);
            _unitOfWork.CancerType.Remove(cancerType);
            await _unitOfWork.Save();
        }

        public async Task Add(CancerTypeViewModel cancerTypeViewModel)
        {
            var cancerType = _mapper.Map<CancerType>(cancerTypeViewModel);
            _unitOfWork.CancerType.Add(cancerType);
            await _unitOfWork.Save();
        }

        public async Task Update(CancerTypeViewModel cancerTypeViewModel)
        {
            var cancerType = _mapper.Map<CancerType>(cancerTypeViewModel);
            _unitOfWork.CancerType.Update(cancerType);
            await _unitOfWork.Save();
        }
    }
}