namespace OncoDiagnose.Web.ViewModels
{
    public class DrugSynonymViewModel
    {
        public int? DrugId { get; set; }
        public DrugViewModel Drug { get; set; }
        public int? SynonymId { get; set; }
        public SynonymViewModel Synonym { get; set; }
    }
}