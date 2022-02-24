using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class RunBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RunBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RunViewModel>> GetAll()
        {
            var runs = await _unitOfWork.Run.GetRunsAsync();
            return runs.Any() ? _mapper.Map<List<RunViewModel>>(runs) : null;
        }

        public async Task<RunViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var run = await _unitOfWork.Run.GetRunByIdAsync(id.GetValueOrDefault());
            return run == null ? null : _mapper.Map<RunViewModel>(run);
        }

        public async Task Delete(RunViewModel runViewModel)
        {
            var run = _mapper.Map<Run>(runViewModel);
            _unitOfWork.Run.Remove(run);
            await _unitOfWork.Save();
        }

        public async Task Add(RunViewModel runViewModel)
        {
            var run = _mapper.Map<Run>(runViewModel);
            _unitOfWork.Run.Add(run);
            await _unitOfWork.Save();
        }

        public async Task Update(RunViewModel runViewModel)
        {
            var run = _mapper.Map<Run>(runViewModel);
            _unitOfWork.Run.Update(run);
            await _unitOfWork.Save();
        }
    }
}