using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class ConsequenceViewModel
    {
        public int Id { get; set; }
        public string Term { get; set; }
        public bool IsGenerallyTruncating { get; set; }
        public string Description { get; set; }
        public List<AlterationViewModel> Alterations { get; set; }
    }
}