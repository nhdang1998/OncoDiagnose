using System.Collections.Generic;
using Newtonsoft.Json;

namespace OncoDiagnose.Models
{
    public class Synonym : BaseEntity
    {
        [JsonProperty("Synonym", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SynonymInformation { get; set; }

        public List<DrugSynonym> DrugSynonyms { get; set; }
    }
}