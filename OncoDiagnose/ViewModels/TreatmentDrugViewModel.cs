namespace OncoDiagnose.Web.ViewModels
{
    public class TreatmentDrugViewModel
    {
        public int? DrugId { get; set; }
        public int? TreatmentId { get; set; }
        public DrugViewModel Drug { get; set; }
        public TreatmentViewModel Treatment { get; set; }
    }
}