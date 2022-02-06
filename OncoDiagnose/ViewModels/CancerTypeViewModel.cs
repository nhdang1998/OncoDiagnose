using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class CancerTypeViewModel
    {
        public int Id { get; set; }
        public List<MutationViewModel> Mutations { get; set; }
        public string Subtype { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }
        public string MainType { get; set; }
        public int Level { get; set; }
        public string Tissue { get; set; }
        public string TumorForm { get; set; }
    }
}