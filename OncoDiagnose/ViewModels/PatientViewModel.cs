using System;
using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string BirthPlace { get; set; }

        public string Country { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Origin { get; set; }

        public string SampleType { get; set; }

        public string OtherDisease { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public int BarCode { get; set; }

        public int KeepMethod { get; set; }

        public int TransportMethod { get; set; }

        public string InspectHospital { get; set; }

        public string InspectDepartment { get; set; }

        public string InsectDoctor { get; set; }

        public DateTime? InspectDate { get; set; }

        public string ReceiveState { get; set; }

        public string DoctorPhone { get; set; }

        public string Sales { get; set; }

        public string Agent { get; set; }

        public string Explain { get; set; }

        public List<TestViewModel> Tests { get; set; }
    }
}