using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OncoDiagnose.Web.ViewModels.DrugViewModels
{
    public class DrugCreateViewModel
    {
        public string NcitCode { get; set; }
        public string DrugName { get; set; }
        public int Priority { get; set; }
        public List<SelectListItem> Synonyms { get; set; }
        public int[] SelectedSynonyms { get; set; }
    }
}
