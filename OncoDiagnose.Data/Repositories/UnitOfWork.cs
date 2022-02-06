using OncoDiagnose.DataAccess.Repositories.Interfaces;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.DataAccess.Repositories.Interfaces.ITechnician;
using OncoDiagnose.DataAccess.Services;
using OncoDiagnose.DataAccess.Services.Technician;
using System.Threading.Tasks;

namespace OncoDiagnose.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OncoDbContext _db;

        public UnitOfWork(OncoDbContext db)
        {
            _db = db;
            Aliase = new AliaseServices(_db);
            Alteration = new AlterationServices(_db);
            Article = new ArticleServices(_db);
            CancerType = new CancerTypeServices(_db);
            Consequence = new ConsequenceServices(_db);
            Drug = new DrugServices(_db);
            DrugSynonym = new DrugSynonymServices(_db);
            GeneAliase = new GeneAliaseServices(_db);
            Gene = new GeneServices(_db);
            Mutation = new MutationServices(_db);
            Synonym = new SynonymServices(_db);
            Treatment = new TreatmentServices(_db);
            Patient = new PatientServices(_db);
            Result = new ResultServices(_db);
            Run = new RunServices(_db);
            Test = new TestServices(_db);
            SpCall = new SP_Call(_db);
        }

        public ISP_Call SpCall { get; private set; }
        public IAliaseRepo Aliase { get; private set; }
        public IAlterationRepo Alteration { get; private set; }
        public IArticleRepo Article { get; private set; }
        public ICancerTypeRepo CancerType { get; private set; }
        public IConsequenceRepo Consequence { get; private set; }
        public IDrugRepo Drug { get; private set; }
        public IDrugSynonymRepo DrugSynonym { get; private set; }
        public IGeneRepo Gene { get; private set; }
        public IGeneAliaseRepo GeneAliase { get; private set; }
        public IMutationRepo Mutation { get; private set; }
        public ISynonymRepo Synonym { get; private set; }
        public ITreatmentRepo Treatment { get; private set; }
        public IPatientRepo Patient { get; private set; }
        public IResultRepo Result { get; private set; }
        public IRunRepo Run { get; private set; }
        public ITestRepo Test { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            var db = await _db.SaveChangesAsync();
            await _db.SaveChangesAsync();
        }
    }
}