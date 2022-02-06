using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class ConsequenceBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ConsequenceBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ConsequenceViewModel>> GetAll()
        {
            var consequences = await _unitOfWork.Consequence.GetAllAsync();
            var tmp = _mapper.Map<List<ConsequenceViewModel>>(consequences);
            return consequences.Any() ? _mapper.Map<List<ConsequenceViewModel>>(consequences) : null;
        }

        public async Task<ConsequenceViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var consequence = await _unitOfWork.Consequence.GetConsequenceByIdAsync(id.GetValueOrDefault());
            return consequence == null ? null : _mapper.Map<ConsequenceViewModel>(consequence);
        }

        public async Task Delete(ConsequenceViewModel consequenceViewModel)
        {
            var consequence = _mapper.Map<Consequence>(consequenceViewModel);
            _unitOfWork.Consequence.Remove(consequence);
            await _unitOfWork.Save();
        }

        public async Task Add(ConsequenceViewModel consequenceViewModel)
        {
            var consequence = _mapper.Map<Consequence>(consequenceViewModel);
            _unitOfWork.Consequence.Add(consequence);
            await _unitOfWork.Save();
        }

        public async Task Update(ConsequenceViewModel consequenceViewModel)
        {
            var consequence = _mapper.Map<Consequence>(consequenceViewModel);
            _unitOfWork.Consequence.Update(consequence);
            await _unitOfWork.Save();
        }
    }
}