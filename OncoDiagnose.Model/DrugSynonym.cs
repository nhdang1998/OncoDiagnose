namespace OncoDiagnose.Models
{
    public class DrugSynonym
    {
        public int? DrugId { get; set; }
        public Drug Drug { get; set; }
        public int? SynonymId { get; set; }
        public Synonym Synonym { get; set; }
    }
}