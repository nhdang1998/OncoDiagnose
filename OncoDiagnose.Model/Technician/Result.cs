using Newtonsoft.Json;

namespace OncoDiagnose.Models.Technician
{
    public class Result : BaseEntity
    {

        [JsonProperty("TestId", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int TestId { get; set; }
        public Test Test { get; set; }

        [JsonProperty("GeneName", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public GeneName GeneName { get; set; }

        [JsonProperty("Variant", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Variant { get; set; }

        [JsonProperty("Frequence", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double Frequence { get; set; }
    }

    public enum GeneName
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
