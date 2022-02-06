using OncoDiagnose.Model.Converter;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models
{
    public class Mutation : BaseEntity
    {

        [JsonPropertyName("EvidenceType")]
        public string EvidenceType { get; set; }

        [JsonPropertyName("Desciption")]
        public string Desciption { get; set; }

        [JsonPropertyName("AdditionalInfor")]
        public string AdditionalInfor { get; set; }

        [JsonPropertyName("KnownEffect")]
        public string KnownEffect { get; set; }

        [JsonPropertyName("LastEdit")]
        [JsonConverter(typeof(InfoToString))]
        public string LastEdit { get; set; }

        [JsonPropertyName("LastReview")]
        public string LastReview { get; set; }

        [JsonPropertyName("LevelOfEvidence")]
        [JsonConverter(typeof(InfoToString))]
        public string LevelOfEvidence { get; set; }

        [JsonPropertyName("SolidPropagationLevel")]
        public string SolidPropagationLevel { get; set; }

        [JsonPropertyName("LiquidPropagationLevel")]
        public string LiquidPropagationLevel { get; set; }
        [JsonPropertyName("CancerTypeId")]
        public int? CancerTypeId { get; set; }
        public CancerType CancerType { get; set; }
        public List<Article> Articles { get; set; }
        public List<MutationArticle> MutationArticles { get; set; }

        public List<Alteration> Alterations { get; set; }
        public List<Treatment> Treatments { get; set; }
    }
}