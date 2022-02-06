using System.Text.Json.Serialization;

namespace OncoDiagnose.Models
{
    public class Alteration : BaseEntity
    {
        [JsonPropertyName("MutationId")]
        public int? MutationId { get; set; }

        public Mutation Mutation { get; set; }

        [JsonPropertyName("Alteration")]
        public string AlterationInformation { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("RefResidues")]
        public string RefResidues { get; set; }

        [JsonPropertyName("ProteinStart")]
        public int ProteinStart { get; set; }

        [JsonPropertyName("ProteinEnd")]
        public int ProteinEnd { get; set; }

        [JsonPropertyName("VariantResidues")]
        public string VariantResidues { get; set; }

        [JsonPropertyName("GeneId")]
        public int? GeneId { get; set; }

        public Gene Gene { get; set; }

        [JsonPropertyName("ConsequenceId")]
        public int? ConsequenceId { get; set; }

        public Consequence Consequence { get; set; }
    }
}