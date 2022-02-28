using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels
{
    public class MutationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string EvidenceType { get; set; }

        public string Desciption { get; set; }

        public string AdditionalInfor { get; set; }

        [Required]
        public string KnownEffect { get; set; }

        public string LastEdit { get; set; }

        public string LastReview { get; set; }

        [Required]
        public string LevelOfEvidence { get; set; }

        public string SolidPropagationLevel { get; set; }

        public string LiquidPropagationLevel { get; set; }

        [Required]
        public int? CancerTypeId { get; set; }

        public CancerTypeViewModel CancerType { get; set; }
        public List<AlterationViewModel> Alterations { get; set; }
        public List<TreatmentViewModel> Treatments { get; set; }
        public List<MutationArticleViewModel> MutationArticles { get; set; }
    }
}