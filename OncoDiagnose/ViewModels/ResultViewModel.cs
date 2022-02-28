using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace OncoDiagnose.Web.ViewModels
{
    public class ResultViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Test")]
        [Required]
        public int TestId { get; set; }

        public TestViewModel Test { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [Required]
        public GeneNameViewModel GeneName { get; set; }

        [Required]
        public string Variant { get; set; }

        [Required]
        public double Frequence { get; set; }
    }

    public enum GeneNameViewModel
    {
        ABL1,
        AKT1,
        ALK,
        APC,
        ATM,
        BRAF,
        CDH1,
        CDKN2A,
        CSF1R,
        CTNNB1,
        EGFR,
        ERBB2,
        ERBB4,
        EZH2,
        FBXW7,
        FGFR1,
        FGFR2,
        FGFR3,
        FLT3,
        GNA11,
        GNAQ,
        GNAS,
        HER4,
        HNF1A,
        HRAS,
        IDH1,
        IDH2,
        JAK2,
        KDR,
        KIT,
        KRAS,
        MET,
        MLH1,
        MPL,
        NOTCH1,
        NPM1,
        NRAS,
        PDGFRA,
        PIK3CA,
        PTEN,
        PTPN11,
        RB1,
        RET,
        SMAD4,
        SMARCB1,
        SMO,
        SRC,
        STK11,
        TP53,
        VHL
    }
}