using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models
{
    public class Treatment : BaseEntity
    {
        [JsonPropertyName("MutationId")]
        public int? MutationId { get; set; }
        public Mutation Mutation { get; set; }

        public int Priority { get; set; }
        public ICollection<Drug> Drugs { get; set; }
        public List<TreatmentDrugs> TreatmentDrugsList { get; set; }

    }
}