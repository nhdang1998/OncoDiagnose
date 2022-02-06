using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class GeneAliaseBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GeneAliaseBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GeneAliaseViewModel>> GetAll()
        {
            var geneAliases = await _unitOfWork.GeneAliase.GetAllAsync();
            return geneAliases.Any() ? _mapper.Map<List<GeneAliaseViewModel>>(geneAliases) : null;
        }

        public async Task<GeneAliaseViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var geneAliase = await _unitOfWork.GeneAliase.GetByIdAsync(id);
            return geneAliase == null ? null : _mapper.Map<GeneAliaseViewModel>(geneAliase);
        }

        public async Task Delete(GeneAliaseViewModel geneAliaseViewModel)
        {
            var geneAliase = _mapper.Map<GeneAliase>(geneAliaseViewModel);
            _unitOfWork.GeneAliase.Remove(geneAliase);
            await _unitOfWork.Save();
        }

        public async Task Add(GeneAliaseViewModel geneAliaseViewModel)
        {
            var geneAliase = _mapper.Map<GeneAliase>(geneAliaseViewModel);
            _unitOfWork.GeneAliase.Add(geneAliase);
            await _unitOfWork.Save();
        }

        public async Task Update(GeneAliaseViewModel geneAliaseViewModel)
        {
            var geneAliase = _mapper.Map<GeneAliase>(geneAliaseViewModel);
            _unitOfWork.GeneAliase.Update(geneAliase);
            await _unitOfWork.Save();
        }
    }
}