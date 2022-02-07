using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OncoDiagnose.Web.ViewModels.DrugViewModels
{
    public class DrugEditViewModel
    {
        public int Id { get; set; }
        public string NcitCode { get; set; }
        public string DrugName { get; set; }
        public int Priority { get; set; }
        public List<SelectListItem> Synonyms { get; set; }
        public int[] SelectedSynonyms { get; set; }
    }
}
