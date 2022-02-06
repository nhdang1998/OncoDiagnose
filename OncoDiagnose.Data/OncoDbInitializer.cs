using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OncoDiagnose.Models;
using OncoDiagnose.Models.Technician;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OncoDiagnose.DataAccess
{
    public class OncoDbInitializer
    {
        public static async Task SeedMutation(OncoDbContext context)
        {
            if (await context.Mutations.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Mutations.json");
            var mutations = await JsonSerializer.DeserializeAsync<List<Mutation>>(stream);

            if (mutations != null)
                await context.Mutations.AddRangeAsync(mutations);
            
            await context.SaveChangesAsync();
        }

        public static async Task SeedCancerType(OncoDbContext context)
        {
            if (await context.CancerTypes.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/CancerTypes.json");
            var cancerTypes = await JsonSerializer.DeserializeAsync<List<CancerType>>(stream);

            if (cancerTypes != null)
                await context.CancerTypes.AddRangeAsync(cancerTypes);

            await context.SaveChangesAsync();
        }

        public static async Task SeedArticle(OncoDbContext context)
        {
            if (await context.Articles.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Articles.json");
            var articles = await JsonSerializer.DeserializeAsync<List<Article>>(stream);

            if (articles != null)
                await context.Articles.AddRangeAsync(articles);
            await context.SaveChangesAsync();
        }

        public static async Task SeedAlteration(OncoDbContext context)
        {
            if (await context.Alterations.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Alterations.json");
            var alterations = await JsonSerializer.DeserializeAsync<List<Alteration>>(stream);

            if (alterations != null)
                await context.Alterations.AddRangeAsync(alterations);
            await context.SaveChangesAsync();
        }

        public static async Task SeedTreatment(OncoDbContext context)
        {
            if (await context.Treatments.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Treatments.json");
            var treatments = await JsonSerializer.DeserializeAsync<List<Treatment>>(stream);

            if (treatments != null)
                await context.Treatments.AddRangeAsync(treatments);

            await context.SaveChangesAsync();
        }

        public static async Task SeedConsequence(OncoDbContext context)
        {
            if (await context.Consequences.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Consequences.json");
            var consequences = await JsonSerializer.DeserializeAsync<List<Consequence>>(stream);

            if (consequences != null)
                await context.Consequences.AddRangeAsync(consequences);

            await context.SaveChangesAsync();
        }

        public static async Task SeedDrug(OncoDbContext context)
        {
            if (await context.Drugs.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Drugs.json");
            var drugs = await JsonSerializer.DeserializeAsync<List<Drug>>(stream);

            if (drugs != null)
                await context.Drugs.AddRangeAsync(drugs);

            await context.SaveChangesAsync();
        }

        public static async Task SeedSynonym(OncoDbContext context)
        {
            if (await context.Synonyms.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Synonyms.json");
            var synonyms = await JsonSerializer.DeserializeAsync<List<Synonym>>(stream);

            if (synonyms != null)
                await context.Synonyms.AddRangeAsync(synonyms);

            await context.SaveChangesAsync();
        }

        public static async Task SeedDrugSynonym(OncoDbContext context)
        {
            if (await context.DrugSynonyms.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/DrugSynonyms.json");
            var drugSynonyms = await JsonSerializer.DeserializeAsync<List<DrugSynonym>>(stream);

            if (drugSynonyms != null)
                await context.DrugSynonyms.AddRangeAsync(drugSynonyms);

            await context.SaveChangesAsync();
        }

        public static async Task SeedGene(OncoDbContext context)
        {
            if (await context.Genes.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Genes.json");
            var genes = await JsonSerializer.DeserializeAsync<List<Gene>>(stream);

            if (genes != null)
                await context.Genes.AddRangeAsync(genes);

            await context.SaveChangesAsync();
        }

        public static async Task SeedAliase(OncoDbContext context)
        {
            if (await context.Aliases.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/Aliases.json");
            var aliases = await JsonSerializer.DeserializeAsync<List<Aliase>>(stream);

            if (aliases != null)
                await context.Aliases.AddRangeAsync(aliases);

            await context.SaveChangesAsync();
        }

        public static async Task SeedGeneAliase(OncoDbContext context)
        {
            if (await context.GeneAliases.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/GeneAliases.json");
            var geneAliases = await JsonSerializer.DeserializeAsync<List<GeneAliase>>(stream);

            if (geneAliases != null)
                await context.GeneAliases.AddRangeAsync(geneAliases);
            await context.SaveChangesAsync();
        }

        public static async Task SeedResult(OncoDbContext context)
        {
            if (await context.Results.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TechnicianUsecaseSeedData/Result.json");
            var text = await File.ReadAllTextAsync(stream.Name);

            //// Using Newtonsoft instead of System.Text.Json because its allow enum type json parsing
            var results = JsonConvert.DeserializeObject<List<Result>>(text);

            if (results != null)
                await context.Results.AddRangeAsync(results);

            await context.SaveChangesAsync();
        }

        public static async Task SeedPatient(OncoDbContext context)
        {
            if (await context.Patients.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TechnicianUsecaseSeedData/Patient.json");
            var patients = await JsonSerializer.DeserializeAsync<List<Patient>>(stream);

            if (patients != null)
                await context.Patients.AddRangeAsync(patients);

            await context.SaveChangesAsync();
        }

        public static async Task SeedRun(OncoDbContext context)
        {
            if (await context.Runs.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TechnicianUsecaseSeedData/Run.json");
            var runs = await JsonSerializer.DeserializeAsync<List<Run>>(stream);

            if (runs != null)
                await context.Runs.AddRangeAsync(runs);

            await context.SaveChangesAsync();
        }

        public static async Task SeedTest(OncoDbContext context)
        {
            if (await context.Tests.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TechnicianUsecaseSeedData/Test.json");
            var tests = await JsonSerializer.DeserializeAsync<List<Test>>(stream);

            if (tests != null)
                foreach (var test in tests)
                {
                    test.TestDate = DateTime.Now;
                    context.Tests.Add(test);
                }
            await context.SaveChangesAsync();
        }

        public static async Task SeedMutationArticle(OncoDbContext context)
        {
            if (await context.MutationArticles.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/MutationArticles.json");
            var mutationArticles = await JsonSerializer.DeserializeAsync<List<MutationArticle>>(stream);

            if (mutationArticles != null)
                await context.MutationArticles.AddRangeAsync(mutationArticles);

            await context.SaveChangesAsync();
        }

        public static async Task SeedTreatmentDrug(OncoDbContext context)
        {
            if (await context.TreatmentDrugs.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TreatmentDrugs.json");
            var treatmentDrugsList = await JsonSerializer.DeserializeAsync<List<TreatmentDrugs>>(stream);

            if (treatmentDrugsList != null)
                await context.TreatmentDrugs.AddRangeAsync(treatmentDrugsList);

            await context.SaveChangesAsync();
        }
    }
}