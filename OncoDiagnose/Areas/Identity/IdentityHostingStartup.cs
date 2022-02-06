using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(OncoDiagnose.Web.Areas.Identity.IdentityHostingStartup))]
namespace OncoDiagnose.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}