using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class MutationBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MutationBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CancerTypeViewModel> GetCancerTypeViewModels()
        {
            var cancerTypes = _unitOfWork.Mutation.GetCancerTypes();
            return cancerTypes.Any() ? _mapper.Map<IEnumerable<CancerTypeViewModel>>(cancerTypes) : null;
        }

        public async Task<List<MutationViewModel>> GetAll()
        {
            var mutations = await _unitOfWork.Mutation.GetMutationsAsync();
            return mutations.Any() ? _mapper.Map<List<MutationViewModel>>(mutations) : null;
        }

        public async Task<MutationViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var mutation = await _unitOfWork.Mutation.GetMutationByIdAsync(id.GetValueOrDefault());
            return mutation == null ? null : _mapper.Map<MutationViewModel>(mutation);
        }

        public async Task Delete(MutationViewModel mutationViewModel)
        {
            var mutation = _mapper.Map<Mutation>(mutationViewModel);
            _unitOfWork.Mutation.Remove(mutation);
            await _unitOfWork.Save();
        }

        public async Task Add(MutationViewModel mutationViewModel)
        {
            var mutation = _mapper.Map<Mutation>(mutationViewModel);
            _unitOfWork.Mutation.Add(mutation);
            await _unitOfWork.Save();
        }

        public async Task Update(MutationViewModel mutationViewModel)
        {
            var mutation = _mapper.Map<Mutation>(mutationViewModel);
            _unitOfWork.Mutation.Update(mutation);
            await _unitOfWork.Save();
        }
    }
}