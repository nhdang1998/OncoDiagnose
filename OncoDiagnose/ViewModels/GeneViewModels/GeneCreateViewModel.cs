using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OncoDiagnose.Web.ViewModels.GeneViewModels
{
    public class GeneCreateViewModel
    {
        public string HugoSymbol { get; set; }
        public string OncoGene { get; set; }

        public string Grch37Isoform { get; set; }

        public string Grch37RefSeq { get; set; }

        public string Grch38Isoform { get; set; }

        public string Grch38RefSeq { get; set; }

        public string Tsg { get; set; }
        public List<SelectListItem> Aliases { get; set; }
        public int[] SelectedAliases { get; set; }
    }
}
