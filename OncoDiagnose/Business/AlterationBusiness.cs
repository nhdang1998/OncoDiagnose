using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class AlterationBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AlterationBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<MutationViewModel> GetMutations()
        {
            var mutations = _unitOfWork.Alteration.GetMutations();
            return mutations.Any() ? _mapper.Map<IEnumerable<MutationViewModel>>(mutations) : null;
        }
        public IEnumerable<GeneViewModel> GetGenes()
        {
            var mutations = _unitOfWork.Alteration.GetGenes();
            return mutations.Any() ? _mapper.Map<IEnumerable<GeneViewModel>>(mutations) : null;
        }
        public IEnumerable<ConsequenceViewModel> GetConsequences()
        {
            var mutations = _unitOfWork.Alteration.GetConsequences();
            return mutations.Any() ? _mapper.Map<IEnumerable<ConsequenceViewModel>>(mutations) : null;
        }

        public async Task<List<AlterationViewModel>> GetAll()
        {
            var alteration = await _unitOfWork.Alteration.GetAlterationsAsync();
            return alteration.Any() ? _mapper.Map<List<AlterationViewModel>>(alteration) : null;
        }

        public async Task<AlterationViewModel> GetById(int id)
        {
            var alteration = await _unitOfWork.Alteration.GetAlterationByIdAsync(id);
            return alteration == null ? null : _mapper.Map<AlterationViewModel>(alteration);
        }

        public async Task Delete(AlterationViewModel alterationViewModel)
        {
            var alteration = _mapper.Map<Alteration>(alterationViewModel);
            _unitOfWork.Alteration.Remove(alteration);
            await _unitOfWork.Save();
        }

        public async Task Add(AlterationViewModel alterationViewModel)
        {
            var alteration = _mapper.Map<Alteration>(alterationViewModel);
            _unitOfWork.Alteration.Add(alteration);
            await _unitOfWork.Save();
        }

        public async Task Update(AlterationViewModel alterationViewModel)
        {
            var alteration = _mapper.Map<Alteration>(alterationViewModel);
            _unitOfWork.Alteration.Update(alteration);
            await _unitOfWork.Save();
        }
    }
}