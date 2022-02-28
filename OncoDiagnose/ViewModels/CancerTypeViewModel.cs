using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels
{
    public class CancerTypeViewModel
    {
        public int Id { get; set; }
        public List<MutationViewModel> Mutations { get; set; }
        public string Subtype { get; set; }
        public string Code { get; set; }
        public string Color { get; set; }

        [Required]
        public string MainType { get; set; }

        public int Level { get; set; }

        [Required]
        public string Tissue { get; set; }

        [Required]
        public string TumorForm { get; set; }
    }
}