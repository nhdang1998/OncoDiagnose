using System.Collections.Generic;
using OncoDiagnose.Web.ViewModels.DrugViewModels;

namespace OncoDiagnose.Web.ViewModels
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }

        public int MutationId { get; set; }

        public MutationViewModel Mutation { get; set; }
        public int Priority { get; set; }
        public List<TreatmentDrugViewModel> TreatmentDrugs { get; set; }
    }
}