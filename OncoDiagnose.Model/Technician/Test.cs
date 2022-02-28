using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OncoDiagnose.Models.Technician
{
    public class Test : BaseEntity
    {
        [JsonProperty("TestName", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TestName { get; set; }

        [JsonProperty("PatientId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [JsonProperty("TestDate", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TestDate { get; set; }

        [JsonProperty("RunId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int RunId { get; set; }

        public Run Run { get; set; }

        public List<Result> Results { get; set; }
    }
}