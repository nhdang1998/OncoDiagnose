using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using OncoDiagnose.Models;
using OncoDiagnose.Models.AuthenticateAndAuthorize;
using OncoDiagnose.Models.Technician;
using OncoDiagnose.Web.ViewModels;
using OncoDiagnose.Web.ViewModels.DrugViewModels;
using OncoDiagnose.Web.ViewModels.GeneViewModels;
using OncoDiagnose.Web.ViewModels.Security;

namespace OncoDiagnose.Web.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Aliase, AliaseViewModel>().ReverseMap();
            CreateMap<Alteration, AlterationViewModel>().ReverseMap();
            CreateMap<Article, ArticleViewModel>().ReverseMap();
            CreateMap<CancerType, CancerTypeViewModel>().ReverseMap();
            CreateMap<Consequence, ConsequenceViewModel>().ReverseMap();
            CreateMap<Drug, DrugViewModel>().ReverseMap();
            CreateMap<DrugSynonym, DrugSynonymViewModel>().ReverseMap();
            CreateMap<Gene, GeneViewModel>().ReverseMap();
            CreateMap<GeneAliase, GeneAliaseViewModel>().ReverseMap();
            CreateMap<Mutation, MutationViewModel>().ReverseMap();
            CreateMap<Synonym, SynonymViewModel>().ReverseMap();
            CreateMap<Treatment, TreatmentViewModel>().ReverseMap();
            CreateMap<TreatmentDrugs, TreatmentDrugViewModel>().ReverseMap();
            CreateMap<MutationArticle, MutationArticleViewModel>().ReverseMap();
            CreateMap<GeneName, GeneNameViewModel>()
                .ConvertUsingEnumMapping(opt => opt
                    // optional: .MapByValue() or MapByName(), without configuration MapByValue is used
                    .MapValue(GeneName.ABL1, GeneNameViewModel.ABL1)
                    .MapValue(GeneName.AKT1, GeneNameViewModel.AKT1)
                    .MapValue(GeneName.ALK, GeneNameViewModel.ALK)
                    .MapValue(GeneName.APC, GeneNameViewModel.APC)
                    .MapValue(GeneName.ATM, GeneNameViewModel.ATM)
                    .MapValue(GeneName.BRAF, GeneNameViewModel.BRAF)
                    .MapValue(GeneName.CDKN2A, GeneNameViewModel.CDKN2A)
                    .MapValue(GeneName.CSF1R, GeneNameViewModel.CSF1R)
                    .MapValue(GeneName.CTNNB1, GeneNameViewModel.CTNNB1)
                    .MapValue(GeneName.CDH1, GeneNameViewModel.CDH1)
                    .MapValue(GeneName.ERBB2, GeneNameViewModel.ERBB2)
                    .MapValue(GeneName.EGFR, GeneNameViewModel.EGFR)
                    .MapValue(GeneName.ERBB4, GeneNameViewModel.ERBB4)
                    .MapValue(GeneName.EZH2, GeneNameViewModel.EZH2)
                    .MapValue(GeneName.FBXW7, GeneNameViewModel.FBXW7)
                    .MapValue(GeneName.FGFR1, GeneNameViewModel.FGFR1)
                    .MapValue(GeneName.FGFR2, GeneNameViewModel.FGFR2)
                    .MapValue(GeneName.FGFR3, GeneNameViewModel.FGFR3)
                    .MapValue(GeneName.FLT3, GeneNameViewModel.FLT3)
                    .MapValue(GeneName.GNA11, GeneNameViewModel.GNA11)
                    .MapValue(GeneName.GNAQ, GeneNameViewModel.GNAQ)
                    .MapValue(GeneName.GNAS, GeneNameViewModel.GNAS)
                    .MapValue(GeneName.HER4, GeneNameViewModel.HER4)
                    .MapValue(GeneName.HNF1A, GeneNameViewModel.HNF1A)
                    .MapValue(GeneName.HRAS, GeneNameViewModel.HRAS)
                    .MapValue(GeneName.IDH1, GeneNameViewModel.IDH1)
                    .MapValue(GeneName.IDH2, GeneNameViewModel.IDH2)
                    .MapValue(GeneName.JAK2, GeneNameViewModel.JAK2)
                    .MapValue(GeneName.KDR, GeneNameViewModel.KDR)
                    .MapValue(GeneName.KIT, GeneNameViewModel.KIT)
                    .MapValue(GeneName.KRAS, GeneNameViewModel.KRAS)
                    .MapValue(GeneName.MET, GeneNameViewModel.MET)
                    .MapValue(GeneName.MLH1, GeneNameViewModel.MLH1)
                    .MapValue(GeneName.MPL, GeneNameViewModel.MPL)
                    .MapValue(GeneName.NOTCH1, GeneNameViewModel.NOTCH1)
                    .MapValue(GeneName.NOTCH1, GeneNameViewModel.NOTCH1)
                    .MapValue(GeneName.NPM1, GeneNameViewModel.NPM1)
                    .MapValue(GeneName.NRAS, GeneNameViewModel.NRAS)
                    .MapValue(GeneName.PDGFRA, GeneNameViewModel.PDGFRA)
                    .MapValue(GeneName.PIK3CA, GeneNameViewModel.PIK3CA)
                    .MapValue(GeneName.PTEN, GeneNameViewModel.PTEN)
                    .MapValue(GeneName.PTPN11, GeneNameViewModel.PTPN11)
                    .MapValue(GeneName.RB1, GeneNameViewModel.RB1)
                    .MapValue(GeneName.RET, GeneNameViewModel.RET)
                    .MapValue(GeneName.SMAD4, GeneNameViewModel.SMAD4)
                    .MapValue(GeneName.SMARCB1, GeneNameViewModel.SMARCB1)
                    .MapValue(GeneName.SMO, GeneNameViewModel.SMO)
                    .MapValue(GeneName.SRC, GeneNameViewModel.SRC)
                    .MapValue(GeneName.TP53, GeneNameViewModel.TP53)
                    .MapValue(GeneName.VHL, GeneNameViewModel.VHL)
                )
                .ReverseMap();
            CreateMap<Patient, PatientViewModel>().ReverseMap();
            CreateMap<Result, ResultViewModel>().ReverseMap();
            CreateMap<Run, RunViewModel>().ReverseMap();
            CreateMap<Test, TestViewModel>().ReverseMap();

            CreateMap<Laboratory, LaboratoryViewModel>().ReverseMap();
        }
    }
}