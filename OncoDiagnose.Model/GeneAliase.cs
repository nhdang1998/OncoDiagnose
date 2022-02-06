namespace OncoDiagnose.Models
{
    public class GeneAliase
    {

        public int? GeneId { get; set; }

        public Gene Gene { get; set; }
        public int? AliaseId { get; set; }

        public Aliase Aliase { get; set; }
    }
}