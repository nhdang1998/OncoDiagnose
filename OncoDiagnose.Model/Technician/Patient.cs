using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OncoDiagnose.Models.Technician
{
    public class Patient : BaseEntity
    {
        [JsonProperty("Name", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("Gender", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Gender { get; set; }

        [JsonProperty("Age", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Age { get; set; }

        [JsonProperty("BirthPlace", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string BirthPlace { get; set; }

        [JsonProperty("Country", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty("PhoneNumber", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty("Address", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty("Origin", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Origin { get; set; }

        [JsonProperty("SampleType", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SampleType { get; set; }

        [JsonProperty("OtherDisease", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string OtherDisease { get; set; }

        [JsonProperty("ReceiveDate", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ReceiveDate { get; set; }

        [JsonProperty("BarCode", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int BarCode { get; set; }

        [JsonProperty("KeepMethod", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int KeepMethod { get; set; }

        [JsonProperty("TransportMethod", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int TransportMethod { get; set; }

        [JsonProperty("InspectHospital", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string InspectHospital { get; set; }

        [JsonProperty("InspectDepartment", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string InspectDepartment { get; set; }

        [JsonProperty("InsectDoctor", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string InsectDoctor { get; set; }

        [JsonProperty("InspectDate", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? InspectDate { get; set; }

        [JsonProperty("ReceiveState", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ReceiveState { get; set; }

        [JsonProperty("DoctorPhone", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string DoctorPhone { get; set; }

        [JsonProperty("Sales", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Sales { get; set; }

        [JsonProperty("Agent", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Agent { get; set; }

        [JsonProperty("Explain", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Explain { get; set; }

        public List<Test> Tests { get; set; }
    }
}