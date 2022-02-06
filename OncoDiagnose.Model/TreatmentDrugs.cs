namespace OncoDiagnose.Models
{
    public class TreatmentDrugs
    {
        public int? DrugId { get; set; }
        public int? TreatmentId { get; set; }
        public Drug Drug { get; set; }
        public Treatment Treatment { get; set; }
    }
}
