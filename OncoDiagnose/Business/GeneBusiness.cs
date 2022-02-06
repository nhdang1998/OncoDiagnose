using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class GeneBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GeneBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GeneViewModel>> GetAll()
        {
            var genes = await _unitOfWork.Gene.GetAllAsync();
            return genes.Any() ? _mapper.Map<List<GeneViewModel>>(genes) : null;
        }

        public async Task<GeneViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var gene = await _unitOfWork.Gene.GetByIdAsync(id);
            return gene == null ? null : _mapper.Map<GeneViewModel>(gene);
        }

        public async Task Delete(GeneViewModel geneViewModel)
        {
            var gene = _mapper.Map<Gene>(geneViewModel);
            _unitOfWork.Gene.Remove(gene);
            await _unitOfWork.Save();
        }

        public async Task Add(GeneViewModel geneViewModel)
        {
            var gene = _mapper.Map<Gene>(geneViewModel);
            _unitOfWork.Gene.Add(gene);
            await _unitOfWork.Save();
        }

        public async Task Update(GeneViewModel geneViewModel)
        {
            var gene = _mapper.Map<Gene>(geneViewModel);
            _unitOfWork.Gene.Update(gene);
            await _unitOfWork.Save();
        }
    }
}