using System;
using Newtonsoft.Json;

namespace OncoDiagnose.Models.Technician
{
    public class Run : BaseEntity
    {
        [JsonProperty("Status", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("FinishDate", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? FinishDate { get; set; }

        [JsonProperty("TotalBase", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string TotalBase { get; set; }

        [JsonProperty("KeySignal", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string KeySignal { get; set; }

        [JsonProperty("TotalRead", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalRead { get; set; }

        [JsonProperty("UsableRead", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double UsableRead { get; set; }

        [JsonProperty("MeanLength", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double MeanLength { get; set; }

        [JsonProperty("MedianLength", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int MedianLength { get; set; }

        [JsonProperty("ModeLength", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int ModeLength { get; set; }

        [JsonProperty("ISPLoading", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ISPLoading { get; set; }

        [JsonProperty("PolyClonal", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string PolyClonal { get; set; }

        [JsonProperty("LowQuality", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int LowQuality { get; set; }

        [JsonProperty("Score", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int Score { get; set; }

        [JsonProperty("ISPLoadingPic", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string ISPLoadingPic { get; set; }

        [JsonProperty("QualityPic", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string QualityPic { get; set; }

        [JsonProperty("LengthPic", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string LengthPic { get; set; }

        public Test Test { get; set; }
    }
}