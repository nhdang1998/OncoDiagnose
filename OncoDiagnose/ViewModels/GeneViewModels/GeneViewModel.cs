using System.Collections.Generic;

namespace OncoDiagnose.Web.ViewModels.GeneViewModels
{
    public class GeneViewModel
    {
        public int Id { get; set; }

        public string HugoSymbol { get; set; }
        public string OncoGene { get; set; }

        public string Grch37Isoform { get; set; }

        public string Grch37RefSeq { get; set; }

        public string Grch38Isoform { get; set; }

        public string Grch38RefSeq { get; set; }

        public string Tsg { get; set; }

        public AlterationViewModel Alteration { get; set; }
        public List<GeneAliaseViewModel> GeneAliases { get; set; }
    }
}