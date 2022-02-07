using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models
{
    public class Gene : BaseEntity
    {
        public string HugoSymbol { get; set; }
        public string OncoGene { get; set; }

        [JsonPropertyName("Grch37Isoform")]
        public string Grch37Isoform { get; set; }

        [JsonPropertyName("Grch37RefSeq")]
        public string Grch37RefSeq { get; set; }

        [JsonPropertyName("grch38Isoform")]
        public string Grch38Isoform { get; set; }

        [JsonPropertyName("grch38RefSeq")]
        public string Grch38RefSeq { get; set; }

        public string Tsg { get; set; }
        public List<Alteration> Alterations { get; set; }
        public List<GeneAliase> GeneAliases { get; set; }
    }
}