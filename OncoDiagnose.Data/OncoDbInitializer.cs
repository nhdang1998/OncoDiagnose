using Newtonsoft.Json;
using OncoDiagnose.Models;
using OncoDiagnose.Models.Technician;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OncoDiagnose.DataAccess
{
    public class OncoDbInitializer
    {
        public static void SeedMutation(OncoDbContext context)
        {
            if (context.Mutations.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Mutations.json");
            var text = File.ReadAllText(stream.Name);
            var mutations = JsonConvert.DeserializeObject<List<Mutation>>(text);

            if (mutations != null)
                context.Mutations.AddRange(mutations);

            context.SaveChanges();
        }

        public static void SeedCancerType(OncoDbContext context)
        {
            if (context.CancerTypes.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/CancerTypes.json");
            var text = File.ReadAllText(stream.Name);
            var cancerTypes = JsonConvert.DeserializeObject<List<CancerType>>(text);

            if (cancerTypes != null)
                context.CancerTypes.AddRange(cancerTypes);

            context.SaveChanges();
        }

        public static void SeedArticle(OncoDbContext context)
        {
            if (context.Articles.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Articles.json");
            var text = File.ReadAllText(stream.Name);
            var articles = JsonConvert.DeserializeObject<List<Article>>(text);

            if (articles != null)
                context.Articles.AddRange(articles);
            context.SaveChanges();
        }

        public static void SeedAlteration(OncoDbContext context)
        {
            if (context.Alterations.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Alterations.json");
            var text = File.ReadAllText(stream.Name);
            var alterations = JsonConvert.DeserializeObject<List<Alteration>>(text);

            if (alterations != null)
                context.Alterations.AddRange(alterations);
            context.SaveChanges();
        }

        public static void SeedTreatment(OncoDbContext context)
        {
            if (context.Treatments.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Treatments.json");
            var text = File.ReadAllText(stream.Name);
            var treatments = JsonConvert.DeserializeObject<List<Treatment>>(text);

            if (treatments != null)
                context.Treatments.AddRange(treatments);

            context.SaveChanges();
        }

        public static void SeedConsequence(OncoDbContext context)
        {
            if (context.Consequences.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Consequences.json");
            var text = File.ReadAllText(stream.Name);
            var consequences = JsonConvert.DeserializeObject<List<Consequence>>(text);

            if (consequences != null)
                context.Consequences.AddRange(consequences);

            context.SaveChanges();
        }

        public static void SeedDrug(OncoDbContext context)
        {
            if (context.Drugs.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Drugs.json");
            var text = File.ReadAllText(stream.Name);
            var drugs = JsonConvert.DeserializeObject<List<Drug>>(text);

            if (drugs != null)
                context.Drugs.AddRange(drugs);

            context.SaveChanges();
        }

        public static void SeedSynonym(OncoDbContext context)
        {
            if (context.Synonyms.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Synonyms.json");
            var text = File.ReadAllText(stream.Name);
            var synonyms = JsonConvert.DeserializeObject<List<Synonym>>(text);

            if (synonyms != null)
                context.Synonyms.AddRange(synonyms);

            context.SaveChanges();
        }

        public static void SeedDrugSynonym(OncoDbContext context)
        {
            if (context.DrugSynonyms.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/DrugSynonyms.json");
            var text = File.ReadAllText(stream.Name);
            var drugSynonyms = JsonConvert.DeserializeObject<List<DrugSynonym>>(text);

            if (drugSynonyms != null)
                context.DrugSynonyms.AddRange(drugSynonyms);

            context.SaveChanges();
        }

        public static void SeedGene(OncoDbContext context)
        {
            if (context.Genes.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Genes.json");
            var text = File.ReadAllText(stream.Name);
            var genes = JsonConvert.DeserializeObject<List<Gene>>(text);

            if (genes != null)
                context.Genes.AddRange(genes);

            context.SaveChanges();
        }

        public static void SeedAliase(OncoDbContext context)
        {
            if (context.Aliases.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/Aliases.json");
            var text = File.ReadAllText(stream.Name);
            var aliases = JsonConvert.DeserializeObject<List<Aliase>>(text);

            if (aliases != null)
                context.Aliases.AddRange(aliases);

            context.SaveChanges();
        }

        public static void SeedGeneAliase(OncoDbContext context)
        {
            if (context.GeneAliases.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/GeneAliases.json");
            var text = File.ReadAllText(stream.Name);
            var geneAliases = JsonConvert.DeserializeObject<List<GeneAliase>>(text);

            if (geneAliases != null)
                context.GeneAliases.AddRange(geneAliases);
            context.SaveChanges();
        }

        public static void SeedResult(OncoDbContext context)
        {
            if (context.Results.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/TechnicianUsecaseSeedData/Result.json");
            var text = File.ReadAllText(stream.Name);

            //// Using Newtonsoft instead of System.Text.Json because its allow enum type json parsing
            var results = JsonConvert.DeserializeObject<List<Result>>(text);

            if (results != null)
                context.Results.AddRange(results);

            context.SaveChanges();
        }

        public static void SeedPatient(OncoDbContext context)
        {
            if (context.Patients.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/TechnicianUsecaseSeedData/Patient.json");
            var text = File.ReadAllText(stream.Name);
            var patients = JsonConvert.DeserializeObject<List<Patient>>(text);

            if (patients != null)
                context.Patients.AddRange(patients);

            context.SaveChanges();
        }

        public static void SeedRun(OncoDbContext context)
        {
            if (context.Runs.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/TechnicianUsecaseSeedData/Run.json");
            var text = File.ReadAllText(stream.Name);
            var runs = JsonConvert.DeserializeObject<List<Run>>(text);

            if (runs != null)
                context.Runs.AddRange(runs);

            context.SaveChanges();
        }

        public static void SeedTest(OncoDbContext context)
        {
            if (context.Tests.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/TechnicianUsecaseSeedData/Test.json");
            var text = File.ReadAllText(stream.Name);
            var tests = JsonConvert.DeserializeObject<List<Test>>(text);

            if (tests != null)
                foreach (var test in tests)
                {
                    test.TestDate = DateTime.Now;
                    context.Tests.Add(test);
                }
            context.SaveChanges();
        }

        public static void SeedMutationArticle(OncoDbContext context)
        {
            if (context.MutationArticles.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/MutationArticles.json");
            var text = File.ReadAllText(stream.Name);
            var mutationArticles = JsonConvert.DeserializeObject<List<MutationArticle>>(text);

            if (mutationArticles != null)
                context.MutationArticles.AddRange(mutationArticles);

            context.SaveChanges();
        }

        public static void SeedTreatmentDrug(OncoDbContext context)
        {
            if (context.TreatmentDrugs.Any()) return;
            using var stream = File.OpenRead("wwwroot/SeedData/TreatmentDrugs.json");
            var text = File.ReadAllText(stream.Name);
            var treatmentDrugsList = JsonConvert.DeserializeObject<List<TreatmentDrugs>>(text);

            if (treatmentDrugsList != null)
                context.TreatmentDrugs.AddRange(treatmentDrugsList);

            context.SaveChanges();
        }
    }
}