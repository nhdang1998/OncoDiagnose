using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels
{
    public class DrugViewModel
    {
        public int Id { get; set; }

        public string NcitCode { get; set; }
        public string DrugName { get; set; }
        public int Priority { get; set; }
        public ICollection<SynonymViewModel> Synonyms { get; set; }

        //public ICollection<TreatmentViewModel> Treatments { get; set; }
        //public List<DrugSynonymViewModel> DrugSynonyms { get; set; }
        //public List<TreatmentDrugViewModel> TreatmentDrugs { get; set; }
    }
}