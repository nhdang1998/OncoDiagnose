using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class SynonymViewModel
    {
        public int Id { get; set; }

        public string SynonymInformation { get; set; }

        public List<DrugSynonymViewModel> DrugSynonyms { get; set; }
        public ICollection<DrugViewModel> Drugs { get; set; }
    }
}