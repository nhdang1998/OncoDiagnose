using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.AuthenticateAndAuthorize;
using OncoDiagnose.Web.ViewModels.Security;

namespace OncoDiagnose.Web.Business.Security
{
    public class LaboratoryBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LaboratoryBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<LaboratoryViewModel>> GetAll()
        {
            var articles = await _unitOfWork.Laboratory.GetAllAsync();
            return articles.Any() ? _mapper.Map<List<LaboratoryViewModel>>(articles) : null;
        }

        public async Task<LaboratoryViewModel> GetById(int id)
        {
            var laboratory = await _unitOfWork.Laboratory.GetByIdAsync(id);
            return laboratory == null ? null : _mapper.Map<LaboratoryViewModel>(laboratory);
        }

        public async Task Delete(LaboratoryViewModel laboratoryViewModel)
        {
            var laboratory = _mapper.Map<Laboratory>(laboratoryViewModel);
            _unitOfWork.Laboratory.Remove(laboratory);
            await _unitOfWork.Save();
        }

        public async Task Add(LaboratoryViewModel laboratoryViewModel)
        {
            var article = _mapper.Map<Laboratory>(laboratoryViewModel);
            _unitOfWork.Laboratory.Add(article);
            await _unitOfWork.Save();
        }

        public async Task Update(LaboratoryViewModel laboratoryViewModel)
        {
            var article = _mapper.Map<Laboratory>(laboratoryViewModel);
            _unitOfWork.Laboratory.Update(article);
            await _unitOfWork.Save();
        }
    }
}