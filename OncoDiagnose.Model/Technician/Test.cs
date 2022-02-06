using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models.Technician
{
    public class Test : BaseEntity
    {
        [JsonPropertyName("TestName")]
        public string TestName { get; set; }

        [JsonPropertyName("PatientId")]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [JsonPropertyName("TestDate")]
        public DateTime? TestDate { get; set; }

        [JsonPropertyName("RunId")]
        public int RunId { get; set; }

        public Run Run { get; set; }

        public List<Result> Results { get; set; }
    }
}
