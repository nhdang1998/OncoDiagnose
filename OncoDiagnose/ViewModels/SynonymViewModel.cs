using System.Collections.Generic;
using OncoDiagnose.Web.ViewModels.DrugViewModels;

namespace OncoDiagnose.Web.ViewModels
{
    public class SynonymViewModel
    {
        public int Id { get; set; }

        public string SynonymInformation { get; set; }

        public List<DrugSynonymViewModel> DrugSynonyms { get; set; }
    }
}