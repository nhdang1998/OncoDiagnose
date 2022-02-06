using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OncoDiagnose.Models.Technician;
using System;
using System.Globalization;

namespace OncoDiagnose.Models.Converter
{
    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                GeneNameConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        public static string GeneNameToString(this GeneName value)
        {
            return value switch
            {
                GeneName.ABL1 => "ABL1",
                GeneName.AKT1 => "AKT1",
                GeneName.ALK => "ALK",
                GeneName.APC => "APC",
                GeneName.ATM => "ATM",
                GeneName.BRAF => "BRAF",
                GeneName.CDH1 => "CDH1",
                GeneName.CDKN2A => "CDKN2A",
                GeneName.CSF1R => "CSF1R",
                GeneName.CTNNB1 => "CTNNB1",
                GeneName.EGFR => "EGFR",
                GeneName.ERBB2 => "ERBB2",
                GeneName.ERBB4 => "ERBB4",
                GeneName.EZH2 => "EZH2",
                GeneName.FBXW7 => "FBXW7",
                GeneName.FGFR1 => "FGFR1",
                GeneName.FGFR2 => "FGFR2",
                GeneName.FGFR3 => "FGFR3",
                GeneName.FLT3 => "FLT3",
                GeneName.GNA11 => "GNA11",
                GeneName.GNAQ => "GNAQ",
                GeneName.GNAS => "GNAS",
                GeneName.HER4 => "HER4",
                GeneName.HNF1A => "HNF1A",
                GeneName.HRAS => "HRAS",
                GeneName.IDH1 => "IDH1",
                GeneName.IDH2 => "IDH2",
                GeneName.JAK2 => "JAK2",
                GeneName.KDR => "KDR",
                GeneName.KIT => "KIT",
                GeneName.KRAS => "KRAS",
                GeneName.MET => "MET",
                GeneName.MLH1 => "MLH1",
                GeneName.MPL => "MPL",
                GeneName.NOTCH1 => "NOTCH1",
                GeneName.NPM1 => "NPM1",
                GeneName.NRAS => "NRAS",
                GeneName.PDGFRA => "PDGFRA",
                GeneName.PIK3CA => "PIK3CA",
                GeneName.PTEN => "PTEN",
                GeneName.PTPN11 => "PTPN11",
                GeneName.RB1 => "RB1",
                GeneName.RET => "RET",
                GeneName.SMAD4 => "SMAD4",
                GeneName.SMARCB1 => "SMARCB1",
                GeneName.SMO => "SMO",
                GeneName.SRC => "SRC",
                GeneName.STK11 => "STK11",
                GeneName.TP53 => "TP53",
                GeneName.VHL => "VHL",
                _ => throw new ArgumentNullException("Gene not available")
            };
        }
    }
}
