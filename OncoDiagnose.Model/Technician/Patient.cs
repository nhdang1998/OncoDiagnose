using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models.Technician
{
    public class Patient : BaseEntity
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Gender")]
        public string Gender { get; set; }

        [JsonPropertyName("Age")]
        public int Age { get; set; }

        [JsonPropertyName("BirthPlace")]
        public string BirthPlace { get; set; }

        [JsonPropertyName("Country")]
        public string Country { get; set; }

        [JsonPropertyName("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("Address")]
        public string Address { get; set; }

        [JsonPropertyName("Origin")]
        public string Origin { get; set; }

        [JsonPropertyName("SampleType")]
        public string SampleType { get; set; }

        [JsonPropertyName("OtherDisease")]
        public string OtherDisease { get; set; }

        [JsonPropertyName("ReceiveDate")]
        public DateTime? ReceiveDate { get; set; }

        [JsonPropertyName("BarCode")]
        public int BarCode { get; set; }

        [JsonPropertyName("KeepMethod")]
        public int KeepMethod { get; set; }

        [JsonPropertyName("TransportMethod")]
        public int TransportMethod { get; set; }

        [JsonPropertyName("InspectHospital")]
        public string InspectHospital { get; set; }

        [JsonPropertyName("InspectDepartment")]
        public string InspectDepartment { get; set; }

        [JsonPropertyName("InsectDoctor")]
        public string InsectDoctor { get; set; }

        [JsonPropertyName("InspectDate")]
        public DateTime? InspectDate { get; set; }

        [JsonPropertyName("ReceiveState")]
        public string ReceiveState { get; set; }

        [JsonPropertyName("DoctorPhone")]
        public string DoctorPhone { get; set; }

        [JsonPropertyName("Sales")]
        public string Sales { get; set; }

        [JsonPropertyName("Agent")]
        public string Agent { get; set; }

        [JsonPropertyName("Explain")]
        public string Explain { get; set; }

        public List<Test> Tests { get; set; }
    }
}