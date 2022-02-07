using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels.DrugViewModels
{
    public class DrugViewModel
    {
        public int Id { get; set; }
        public string NcitCode { get; set; }
        public string DrugName { get; set; }
        public int Priority { get; set; }

        public List<DrugSynonymViewModel> DrugSynonyms { get; set; } = new List<DrugSynonymViewModel>();
        public List<TreatmentDrugViewModel> TreatmentDrugs { get; set; }
    }
}