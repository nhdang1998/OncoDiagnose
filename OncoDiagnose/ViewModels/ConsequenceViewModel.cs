using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OncoDiagnose.Web.ViewModels
{
    public class ConsequenceViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Term { get; set; }

        [Required]
        public bool IsGenerallyTruncating { get; set; }

        public string Description { get; set; }
        public List<AlterationViewModel> Alterations { get; set; }
    }
}