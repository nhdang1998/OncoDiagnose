using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OncoDiagnose.DataAccess;
using OncoDiagnose.DataAccess.Repositories;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Web.Automapper;
using OncoDiagnose.Web.Business;

namespace OncoDiagnose.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OncoDbContext>(option =>
                option
                    .EnableSensitiveDataLogging()
                    //.UseLazyLoadingProxies() //// Enable LazyLoading
                    .UseSqlServer(Configuration.GetConnectionString("OncoDiagnoseConnection")));
            services.AddControllersWithViews();

            services.AddAutoMapper
                (typeof(MapperProfile).Assembly);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AliaseBusiness>();
            services.AddScoped<AlterationBusiness>();
            services.AddScoped<ArticleBusiness>();
            services.AddScoped<CancerTypeBusiness>();
            services.AddScoped<ConsequenceBusiness>();
            services.AddScoped<DrugBusiness>();
            services.AddScoped<DrugSynonymBusiness>();
            services.AddScoped<GeneAliaseBusiness>();
            services.AddScoped<GeneBusiness>();
            services.AddScoped<MutationBusiness>();
            services.AddScoped<PatientBusiness>();
            services.AddScoped<ResultBusiness>();
            services.AddScoped<RunBusiness>();
            services.AddScoped<SynonymBusiness>();
            services.AddScoped<TestBusiness>();
            services.AddScoped<TreatmentBusiness>();

            //// Avoid loop references
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Doctor}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}