using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models
{
    public class Synonym : BaseEntity
    {
        [JsonPropertyName("Synonym")]
        public string SynonymInformation { get; set; }

        public List<DrugSynonym> DrugSynonyms { get; set; }
    }
}