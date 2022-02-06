using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }

        public int MutationId { get; set; }

        public MutationViewModel Mutation { get; set; }
        public int Priority { get; set; }
        public ICollection<DrugViewModel> Drugs { get; set; }
        public List<TreatmentDrugViewModel> TreatmentDrugsList { get; set; }
    }
}