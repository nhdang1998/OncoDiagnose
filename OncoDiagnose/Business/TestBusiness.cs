using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class TestBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public TestBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<TestViewModel>> GetAll()
        {
            var tests = await _unitOfWork.Test.GetAllAsync();
            return tests.Any() ? _mapper.Map<List<TestViewModel>>(tests) : null;
        }

        public async Task<TestViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var test = await _unitOfWork.Test.GetByIdAsync(id);
            return test == null ? null : _mapper.Map<TestViewModel>(test);
        }

        public async Task Delete(TestViewModel testViewModel)
        {
            var test = _mapper.Map<Test>(testViewModel);
            _unitOfWork.Test.Remove(test);
            await _unitOfWork.Save();
        }

        public async Task Add(TestViewModel testViewModel)
        {
            var test = _mapper.Map<Test>(testViewModel);
            _unitOfWork.Test.Add(test);
            await _unitOfWork.Save();
        }

        public async Task Update(TestViewModel testViewModel)
        {
            var test = _mapper.Map<Test>(testViewModel);
            _unitOfWork.Test.Update(test);
            await _unitOfWork.Save();
        }
    }
}