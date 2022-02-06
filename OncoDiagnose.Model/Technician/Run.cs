using System.Text.Json.Serialization;

namespace OncoDiagnose.Models.Technician
{
    public class Run : BaseEntity
    {
        [JsonPropertyName("Status")]
        public string Status { get; set; }

        [JsonPropertyName("FinishDate")]
        public string FinishDate { get; set; }

        [JsonPropertyName("TotalBase")]
        public string TotalBase { get; set; }

        [JsonPropertyName("KeySignal")]
        public string KeySignal { get; set; }

        [JsonPropertyName("TotalRead")]
        public int TotalRead { get; set; }

        [JsonPropertyName("UsableRead")]
        public double UsableRead { get; set; }

        [JsonPropertyName("MeanLength")]
        public double MeanLength { get; set; }

        [JsonPropertyName("MedianLength")]
        public int MedianLength { get; set; }

        [JsonPropertyName("ModeLength")]
        public int ModeLength { get; set; }

        [JsonPropertyName("ISPLoading")]
        public string ISPLoading { get; set; }

        [JsonPropertyName("PolyClonal")]
        public string PolyClonal { get; set; }

        [JsonPropertyName("LowQuality")]
        public int LowQuality { get; set; }

        [JsonPropertyName("Score")]
        public int Score { get; set; }

        [JsonPropertyName("ISPLoadingPic")]
        public string ISPLoadingPic { get; set; }

        [JsonPropertyName("QualityPic")]
        public string QualityPic { get; set; }

        [JsonPropertyName("LengthPic")]
        public string LengthPic { get; set; }
        public Test Test { get; set; }
    }
}
