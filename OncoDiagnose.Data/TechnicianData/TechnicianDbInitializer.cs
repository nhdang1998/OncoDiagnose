using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OncoDiagnose.Models.Technician;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace OncoDiagnose.DataAccess.TechnicianData
{
    public class TechnicianDbInitializer
    {
        public static async Task SeedResult(TechnicianDbContext context)
        {
            if (await context.Results.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TechnicianUsecaseSeedData/Result.json");
            var text = await File.ReadAllTextAsync(stream.Name);

            //// Using Newtonsoft instead of System.Text.Json because its allow enum type json parsing
            var results = JsonConvert.DeserializeObject<List<Result>>(text);

            if (results != null)
                foreach (var result in results)
                {
                    context.Results.Add(result);
                }

            await context.SaveChangesAsync();
        }

        public static async Task SeedPatient(TechnicianDbContext context)
        {
            if (await context.Patients.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TechnicianUsecaseSeedData/Patient.json");
            var patients = await JsonSerializer.DeserializeAsync<List<Patient>>(stream);

            if (patients != null)
                foreach (var patient in patients)
                {
                    context.Patients.Add(patient);
                }
            await context.SaveChangesAsync();
        }

        public static async Task SeedRun(TechnicianDbContext context)
        {
            if (await context.Runs.AnyAsync()) return;
            await using var stream = File.OpenRead("SeedData/TechnicianUsecaseSeedData/Run.json");
            var runs = await JsonSerializer.DeserializeAsync<List<Run>>(stream);

            if (runs != null)
                foreach (var run in runs)
                {
                    context.Runs.Add(run);
                }
            await context.SaveChangesAsync();
        }

        public static async Task SeedTest(TechnicianDbContext context)
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
    }
}
