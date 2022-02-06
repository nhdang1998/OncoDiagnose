using System.Collections.Generic;
using OncoDiagnose.Model.Converter;
using System.Text.Json.Serialization;

namespace OncoDiagnose.Models
{
    public class Article : BaseEntity
    {
        public List<Mutation> Mutations { get; set; }

        [JsonConverter(typeof(InfoToString))]
        public string Pmid { get; set; }

        public string Title { get; set; }
        public string Journal { get; set; }

        [JsonConverter(typeof(InfoToString))]
        public string PubDate { get; set; }

        [JsonConverter(typeof(InfoToString))]
        public string Volume { get; set; }

        [JsonConverter(typeof(InfoToString))]
        public string Issue { get; set; }

        [JsonConverter(typeof(InfoToString))]
        public string Pages { get; set; }
        public string Authors { get; set; }
        public string ElocationId { get; set; }
        public string Link { get; set; }
        public string Reference { get; set; }
        public string Abstract { get; set; }
        public List<MutationArticle> MutationArticles { get; set; }


    }
}