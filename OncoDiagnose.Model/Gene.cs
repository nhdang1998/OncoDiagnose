using System.Collections.Generic;
using Newtonsoft.Json;

namespace OncoDiagnose.Models
{
    public class Gene : BaseEntity
    {
        public string HugoSymbol { get; set; }
        public string OncoGene { get; set; }

        [JsonProperty("Grch37Isoform", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Grch37Isoform { get; set; }

        [JsonProperty("Grch37RefSeq", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Grch37RefSeq { get; set; }

        [JsonProperty("Grch38Isoform", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Grch38Isoform { get; set; }

        [JsonProperty("Grch38RefSeq", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Grch38RefSeq { get; set; }

        public string Tsg { get; set; }
        public List<Alteration> Alterations { get; set; }
        public List<GeneAliase> GeneAliases { get; set; }
    }
}