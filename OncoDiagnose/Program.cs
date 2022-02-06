using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OncoDiagnose.DataAccess;
using System;
using System.Threading.Tasks;

namespace OncoDiagnose.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<OncoDbContext>();
                await context.Database.MigrateAsync();
                await OncoDbInitializer.SeedCancerType(context);
                await OncoDbInitializer.SeedMutation(context);
                await OncoDbInitializer.SeedConsequence(context);
                await OncoDbInitializer.SeedGene(context);
                await OncoDbInitializer.SeedAlteration(context);
                await OncoDbInitializer.SeedArticle(context);
                await OncoDbInitializer.SeedTreatment(context);
                await OncoDbInitializer.SeedDrug(context);
                await OncoDbInitializer.SeedSynonym(context);
                await OncoDbInitializer.SeedDrugSynonym(context);
                await OncoDbInitializer.SeedAliase(context);
                await OncoDbInitializer.SeedGeneAliase(context);
                await OncoDbInitializer.SeedMutationArticle(context);
                await OncoDbInitializer.SeedTreatmentDrug(context);

                await OncoDbInitializer.SeedPatient(context);
                await OncoDbInitializer.SeedRun(context);
                await OncoDbInitializer.SeedTest(context);
                await OncoDbInitializer.SeedResult(context);
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(e, "An error during migration");
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}