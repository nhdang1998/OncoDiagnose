using System.Collections.Generic;
using Newtonsoft.Json;

namespace OncoDiagnose.Models
{
    public class Treatment : BaseEntity
    {
        [JsonProperty("MutationId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? MutationId { get; set; }

        public Mutation Mutation { get; set; }

        public int Priority { get; set; }
        public List<TreatmentDrugs> TreatmentDrugs { get; set; }
    }
}