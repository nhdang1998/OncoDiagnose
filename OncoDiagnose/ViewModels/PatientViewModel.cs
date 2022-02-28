using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string BirthPlace { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string SampleType { get; set; }

        public string OtherDisease { get; set; }

        public DateTime? ReceiveDate { get; set; }

        public int BarCode { get; set; }

        [Required]
        public int KeepMethod { get; set; }

        public int TransportMethod { get; set; }

        [Required]
        public string InspectHospital { get; set; }

        [Required]
        public string InspectDepartment { get; set; }

        [Required]
        public string InsectDoctor { get; set; }

        [Required]
        public DateTime InspectDate { get; set; }

        [Required]
        public string ReceiveState { get; set; }

        [Required]
        public string DoctorPhone { get; set; }

        [Required]
        public string Sales { get; set; }

        [Required]
        public string Agent { get; set; }

        public string Explain { get; set; }

        public List<TestViewModel> Tests { get; set; }
    }
}