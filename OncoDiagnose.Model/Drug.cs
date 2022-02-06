using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models
{
    public class Drug : BaseEntity
    {
        public string NcitCode { get; set; }
        public string DrugName { get; set; }

        public int Priority { get; set; }
        public List<DrugSynonym> DrugSynonyms { get; set; }
        public ICollection<Synonym> Synonyms { get; set; }
        public ICollection<Treatment> Treatments { get; set; }
        public List<TreatmentDrugs> TreatmentDrugs { get; set; }
    }
}