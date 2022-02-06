using AutoMapper;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Models.Technician;
using OncoDiagnose.Web.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OncoDiagnose.Web.Business
{
    public class PatientBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PatientBusiness(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<PatientViewModel>> GetAll()
        {
            var patients = await _unitOfWork.Patient.GetAllAsync();
            return patients.Any() ? _mapper.Map<List<PatientViewModel>>(patients) : null;
        }

        public async Task<PatientViewModel> GetById(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var patient = await _unitOfWork.Patient.GetByIdAsync(id);
            return patient == null ? null : _mapper.Map<PatientViewModel>(patient);
        }

        public async Task Delete(PatientViewModel patientViewModel)
        {
            var patient = _mapper.Map<Patient>(patientViewModel);
            _unitOfWork.Patient.Remove(patient);
            await _unitOfWork.Save();
        }

        public async Task Add(PatientViewModel patientViewModel)
        {
            var patient = _mapper.Map<Patient>(patientViewModel);
            _unitOfWork.Patient.Add(patient);
            await _unitOfWork.Save();
        }

        public async Task Update(PatientViewModel patientViewModel)
        {
            var patient = _mapper.Map<Patient>(patientViewModel);
            _unitOfWork.Patient.Update(patient);
            await _unitOfWork.Save();
        }
    }
}