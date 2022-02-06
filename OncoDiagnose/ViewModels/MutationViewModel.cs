using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class MutationViewModel
    {
        public int Id { get; set; }

        public string EvidenceType { get; set; }

        public string Desciption { get; set; }

        public string AdditionalInfor { get; set; }

        public string KnownEffect { get; set; }

        public string LastEdit { get; set; }

        public string LastReview { get; set; }

        public string LevelOfEvidence { get; set; }

        public string SolidPropagationLevel { get; set; }

        public string LiquidPropagationLevel { get; set; }
        public int? CancerTypeId { get; set; }
        public CancerTypeViewModel CancerType { get; set; }
        public List<ArticleViewModel> Articles { get; set; }
        public List<AlterationViewModel> Alterations { get; set; }
        public List<TreatmentViewModel> Treatments { get; set; }
        public List<MutationArticleViewModel> MutationArticleViewModels { get; set; }
    }
}