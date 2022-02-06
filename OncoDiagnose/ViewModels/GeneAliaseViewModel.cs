namespace OncoDiagnose.Web.ViewModels
{
    public class GeneAliaseViewModel
    {
        public int GeneId { get; set; }
        public GeneViewModel Gene { get; set; }
        public int AliaseId { get; set; }
        public AliaseViewModel Aliase { get; set; }
    }
}