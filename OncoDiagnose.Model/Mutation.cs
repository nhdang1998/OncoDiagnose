using OncoDiagnose.Model.Converter;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OncoDiagnose.Models
{
    public class Mutation : BaseEntity
    {
        [JsonProperty("EvidenceType", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string EvidenceType { get; set; }

        [JsonProperty("Desciption", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Desciption { get; set; }

        [JsonProperty("AdditionalInfor", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string AdditionalInfor { get; set; }

        [JsonProperty("KnownEffect", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string KnownEffect { get; set; }

        [JsonProperty("LastEdit", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonConverter(typeof(InfoToString))]
        public string LastEdit { get; set; }

        [JsonProperty("LastReview", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string LastReview { get; set; }

        [JsonProperty("LevelOfEvidence", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        [System.Text.Json.Serialization.JsonConverter(typeof(InfoToString))]
        public string LevelOfEvidence { get; set; }

        [JsonProperty("SolidPropagationLevel", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string SolidPropagationLevel { get; set; }

        [JsonProperty("LiquidPropagationLevel", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string LiquidPropagationLevel { get; set; }

        [JsonProperty("CancerTypeId", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? CancerTypeId { get; set; }

        public CancerType CancerType { get; set; }
        public List<MutationArticle> MutationArticles { get; set; }

        public List<Alteration> Alterations { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}