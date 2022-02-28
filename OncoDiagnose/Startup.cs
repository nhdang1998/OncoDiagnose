using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OncoDiagnose.DataAccess;
using OncoDiagnose.DataAccess.Initializer;
using OncoDiagnose.DataAccess.Repositories;
using OncoDiagnose.DataAccess.Repositories.Interfaces.Base;
using OncoDiagnose.Utility;
using OncoDiagnose.Web.Automapper;
using OncoDiagnose.Web.Business;
using OncoDiagnose.Web.Business.Security;

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
                    .UseSqlServer(Configuration.GetConnectionString("OncoDiagnoseConnection"), builder =>
                    {
                        builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                    }));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<OncoDbContext>();

            //Doi sang AddIdentity vi AddDefault khong co role
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders() //Neu comment doan gui mail thi no se ko tu tao ra token nua nen can tao mac dinh
                .AddEntityFrameworkStores<OncoDbContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddMvc();
            services.AddAutoMapper
                (typeof(MapperProfile).Assembly);

            services.AddSingleton<IEmailSender, EmailSender>();
            services.Configure<EmailOptions>(Configuration);

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

            services.AddScoped<LaboratoryBusiness>();

            //// Avoid loop references
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseHttpsRedirection();
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

            app.UseAuthentication();
            app.UseAuthorization();

            dbInitializer.Initialize();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{area=Doctor}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}