using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class ResultBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ResultBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ResultViewModel>> GetAll()
        {
            var results = await _unitOfWork.Result.GetResultsAsync();
            return results.Any() ? _mapper.Map<List<ResultViewModel>>(results) : null;
        }

        public IEnumerable<TestViewModel> GetTestsTestViewModels()
        {
            var tests = _unitOfWork.Result.GetTests();
            return tests.Any() ? _mapper.Map<IEnumerable<TestViewModel>>(tests) : null;
        }

        public async Task<ResultViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var result = await _unitOfWork.Result.GetResultByIdAsync(id.GetValueOrDefault());
            return result == null ? null : _mapper.Map<ResultViewModel>(result);
        }

        public async Task Delete(ResultViewModel resultViewModel)
        {
            var result = _mapper.Map<Result>(resultViewModel);
            _unitOfWork.Result.Remove(result);
            await _unitOfWork.Save();
        }

        public async Task Add(ResultViewModel resultViewModel)
        {
            var result = _mapper.Map<Result>(resultViewModel);
            _unitOfWork.Result.Add(result);
            await _unitOfWork.Save();
        }

        public async Task Update(ResultViewModel resultViewModel)
        {
            var result = _mapper.Map<Result>(resultViewModel);
            _unitOfWork.Result.Update(result);
            await _unitOfWork.Save();
        }

        public async Task AddRange(List<ResultViewModel> resultViewModels)
        {
            var results = _mapper.Map<List<Result>>(resultViewModels);
            _unitOfWork.Result.AddRange(results);
            await _unitOfWork.Save();
        }
    }
}