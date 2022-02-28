using Newtonsoft.Json;

namespace OncoDiagnose.Models
{
    public class Alteration : BaseEntity
    {
        [JsonProperty("MutationId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? MutationId { get; set; }

        public Mutation Mutation { get; set; }

        [JsonProperty("Alteration", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AlterationInformation { get; set; }

        [JsonProperty("Name", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("RefResidues", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string RefResidues { get; set; }

        [JsonProperty("ProteinStart", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int ProteinStart { get; set; }

        [JsonProperty("ProteinEnd", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int ProteinEnd { get; set; }

        [JsonProperty("VariantResidues", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string VariantResidues { get; set; }

        [JsonProperty("GeneId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? GeneId { get; set; }

        public Gene Gene { get; set; }

        [JsonProperty("ConsequenceId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? ConsequenceId { get; set; }

        public Consequence Consequence { get; set; }
    }
}