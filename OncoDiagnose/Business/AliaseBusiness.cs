using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class AliaseBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AliaseBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<AliaseViewModel>> GetAll()
        {
            var aliases = await _unitOfWork.Aliase.GetAliasesAsync();
            return aliases.Any() ? _mapper.Map<List<AliaseViewModel>>(aliases) : null;
        }

        public async Task<AliaseViewModel> GetById(int id)
        {
            var aliase = await _unitOfWork.Aliase.GetAliaseByIdAsync(id);
            return aliase == null ? null : _mapper.Map<AliaseViewModel>(aliase);
        }

        public async Task Delete(AliaseViewModel aliaseViewModel)
        {
            var aliase = _mapper.Map<Aliase>(aliaseViewModel);
            _unitOfWork.Aliase.Remove(aliase);
            await _unitOfWork.Save();
        }

        public async Task Add(AliaseViewModel aliaseViewModel)
        {
            var aliase = _mapper.Map<Aliase>(aliaseViewModel);
            _unitOfWork.Aliase.Add(aliase);
            await _unitOfWork.Save();
        }

        public async Task Update(AliaseViewModel aliaseViewModel)
        {
            var aliase = _mapper.Map<Aliase>(aliaseViewModel);
            _unitOfWork.Aliase.Update(aliase);
            await _unitOfWork.Save();
        }
    }
}