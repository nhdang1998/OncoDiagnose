using Newtonsoft.Json;
using OncoDiagnose.Models.Technician;
using System;

namespace OncoDiagnose.Models.Converter
{
    public class GeneNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t)
        {
            return t == typeof(GeneName) || t == typeof(GeneName?);
        }

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            return value switch
            {
                "ABL1" => GeneName.ABL1,
                "AKT1" => GeneName.AKT1,
                "ALK" => GeneName.ALK,
                "APC" => GeneName.APC,
                "ATM" => GeneName.ATM,
                "BRAF" => GeneName.BRAF,
                "CDH1" => GeneName.CDH1,
                "CDKN2A" => GeneName.CDKN2A,
                "CSF1R" => GeneName.CSF1R,
                "CTNNB1" => GeneName.CTNNB1,
                "EGFR" => GeneName.EGFR,
                "ERBB2" => GeneName.ERBB2,
                "ERBB4" => GeneName.ERBB4,
                "EZH2" => GeneName.EZH2,
                "FBXW7" => GeneName.FBXW7,
                "FGFR1" => GeneName.FGFR1,
                "FGFR2" => GeneName.FGFR2,
                "FGFR3" => GeneName.FGFR3,
                "FLT3" => GeneName.FLT3,
                "GNA11" => GeneName.GNA11,
                "GNAQ" => GeneName.GNAQ,
                "GNAS" => GeneName.GNAS,
                "HER4" => GeneName.HER4,
                "HNF1A" => GeneName.HNF1A,
                "HRAS" => GeneName.HRAS,
                "IDH1" => GeneName.IDH1,
                "IDH2" => GeneName.IDH2,
                "JAK2" => GeneName.JAK2,
                "KDR" => GeneName.KDR,
                "KIT" => GeneName.KIT,
                "KRAS" => GeneName.KRAS,
                "MET" => GeneName.MET,
                "MLH1" => GeneName.MLH1,
                "MPL" => GeneName.MPL,
                "NOTCH1" => GeneName.NOTCH1,
                "NPM1" => GeneName.NPM1,
                "NRAS" => GeneName.NRAS,
                "PDGFRA" => GeneName.PDGFRA,
                "PIK3CA" => GeneName.PIK3CA,
                "PTEN" => GeneName.PTEN,
                "PTPN11" => GeneName.PTPN11,
                "RB1" => GeneName.RB1,
                "RET" => GeneName.RET,
                "SMAD4" => GeneName.SMAD4,
                "SMARCB1" => GeneName.SMARCB1,
                "SMO" => GeneName.SMO,
                "SRC" => GeneName.SRC,
                "STK11" => GeneName.STK11,
                "TP53" => GeneName.TP53,
                "VHL" => GeneName.VHL,
                _ => throw new Exception("Cannot unmarshal type GeneName")
            };
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (GeneName)untypedValue;
            switch (value)
            {
                case GeneName.ABL1:
                    serializer.Serialize(writer, "ABL1");
                    return;
                case GeneName.AKT1:
                    serializer.Serialize(writer, "AKT1");
                    return;
                case GeneName.ALK:
                    serializer.Serialize(writer, "ALK");
                    return;
                case GeneName.APC:
                    serializer.Serialize(writer, "APC");
                    return;
                case GeneName.ATM:
                    serializer.Serialize(writer, "ATM");
                    return;
                case GeneName.BRAF:
                    serializer.Serialize(writer, "BRAF");
                    return;
                case GeneName.CDKN2A:
                    serializer.Serialize(writer, "CDKN2A");
                    return;
                case GeneName.CSF1R:
                    serializer.Serialize(writer, "CSF1R");
                    return;
                case GeneName.CTNNB1:
                    serializer.Serialize(writer, "CTNNB1");
                    return;
                case GeneName.CDH1:
                    serializer.Serialize(writer, "CDH1");
                    return;
                case GeneName.EGFR:
                    serializer.Serialize(writer, "EGFR");
                    return;
                case GeneName.ERBB2:
                    serializer.Serialize(writer, "ERBB2");
                    return;
                case GeneName.ERBB4:
                    serializer.Serialize(writer, "ERBB4");
                    return;
                case GeneName.EZH2:
                    serializer.Serialize(writer, "EZH2");
                    return;
                case GeneName.FBXW7:
                    serializer.Serialize(writer, "FBXW7");
                    return;
                case GeneName.FGFR1:
                    serializer.Serialize(writer, "FGFR1");
                    return;
                case GeneName.FGFR2:
                    serializer.Serialize(writer, "FGFR2");
                    return;
                case GeneName.FGFR3:
                    serializer.Serialize(writer, "FGFR3");
                    return;
                case GeneName.FLT3:
                    serializer.Serialize(writer, "FLT3");
                    return;
                case GeneName.GNA11:
                    serializer.Serialize(writer, "GNA11");
                    return;
                case GeneName.GNAQ:
                    serializer.Serialize(writer, "GNAQ");
                    return;
                case GeneName.GNAS:
                    serializer.Serialize(writer, "GNAS");
                    return;
                case GeneName.HER4:
                    serializer.Serialize(writer, "HER4");
                    return;
                case GeneName.HNF1A:
                    serializer.Serialize(writer, "HNF1A");
                    return;
                case GeneName.HRAS:
                    serializer.Serialize(writer, "HRAS");
                    return;
                case GeneName.IDH1:
                    serializer.Serialize(writer, "IDH1");
                    return;
                case GeneName.IDH2:
                    serializer.Serialize(writer, "IDH2");
                    return;
                case GeneName.JAK2:
                    serializer.Serialize(writer, "JAK2");
                    return;
                case GeneName.KDR:
                    serializer.Serialize(writer, "KDR");
                    return;
                case GeneName.KIT:
                    serializer.Serialize(writer, "KIT");
                    return;
                case GeneName.KRAS:
                    serializer.Serialize(writer, "KRAS");
                    return;
                case GeneName.MET:
                    serializer.Serialize(writer, "MET");
                    return;
                case GeneName.MLH1:
                    serializer.Serialize(writer, "MLH1");
                    return;
                case GeneName.MPL:
                    serializer.Serialize(writer, "MPL");
                    return;
                case GeneName.NOTCH1:
                    serializer.Serialize(writer, "NOTCH1");
                    return;
                case GeneName.NPM1:
                    serializer.Serialize(writer, "NPM1");
                    return;
                case GeneName.NRAS:
                    serializer.Serialize(writer, "NRAS");
                    return;
                case GeneName.PDGFRA:
                    serializer.Serialize(writer, "PDGFRA");
                    return;
                case GeneName.PIK3CA:
                    serializer.Serialize(writer, "PIK3CA");
                    return;
                case GeneName.PTEN:
                    serializer.Serialize(writer, "PTEN");
                    return;
                case GeneName.PTPN11:
                    serializer.Serialize(writer, "PTPN11");
                    return;
                case GeneName.RB1:
                    serializer.Serialize(writer, "RB1");
                    return;
                case GeneName.RET:
                    serializer.Serialize(writer, "RET");
                    return;
                case GeneName.SMAD4:
                    serializer.Serialize(writer, "SMAD4");
                    return;
                case GeneName.SMARCB1:
                    serializer.Serialize(writer, "SMARCB1");
                    return;
                case GeneName.SMO:
                    serializer.Serialize(writer, "SMO");
                    return;
                case GeneName.SRC:
                    serializer.Serialize(writer, "SRC");
                    return;
                case GeneName.STK11:
                    serializer.Serialize(writer, "STK11");
                    return;
                case GeneName.TP53:
                    serializer.Serialize(writer, "TP53");
                    return;
                case GeneName.VHL:
                    serializer.Serialize(writer, "VHL");
                    return;
                default:
                    throw new ArgumentOutOfRangeException("Cannot marshal type GeneName");
            }
        }

        public static readonly GeneNameConverter Singleton = new GeneNameConverter();
    }
}
