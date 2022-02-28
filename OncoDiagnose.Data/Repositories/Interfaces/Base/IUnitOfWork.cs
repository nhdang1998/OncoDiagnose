using OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician;
using System;
using System.Threading.Tasks;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ISecurity;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IAliaseRepo Aliase { get; }
        IAlterationRepo Alteration { get; }
        IArticleRepo Article { get; }
        ICancerTypeRepo CancerType { get; }
        IConsequenceRepo Consequence { get; }
        IDrugRepo Drug { get; }
        IDrugSynonymRepo DrugSynonym { get; }
        IGeneRepo Gene { get; }
        IGeneAliaseRepo GeneAliase { get; }
        IMutationRepo Mutation { get; }
        ISynonymRepo Synonym { get; }
        ITreatmentRepo Treatment { get; }
        IPatientRepo Patient { get; }
        IResultRepo Result { get; }
        IRunRepo Run { get; }
        ITestRepo Test { get; }

        ILaboratoryRepo Laboratory { get; }
        IUserRepo User { get; }

        Task Save();
    }
}