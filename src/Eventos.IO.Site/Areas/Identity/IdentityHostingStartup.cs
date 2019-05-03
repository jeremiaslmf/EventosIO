using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Eventos.IO.Site.Areas.Identity.IdentityHostingStartup))]
namespace Eventos.IO.Site.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}