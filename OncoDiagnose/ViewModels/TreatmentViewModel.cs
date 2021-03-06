using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OncoDiagnose.Web.ViewModels.DrugViewModels;

namespace OncoDiagnose.Web.ViewModels
{
    public class TreatmentViewModel
    {
        public int Id { get; set; }

        [Required]
        public int MutationId { get; set; }

        public MutationViewModel Mutation { get; set; }

        [Required]
        public int Priority { get; set; }

        public List<TreatmentDrugViewModel> TreatmentDrugs { get; set; }
    }
}