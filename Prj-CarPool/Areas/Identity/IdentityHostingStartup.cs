[assembly: HostingStartup(typeof(Prj_CarPool.Areas.Identity.IdentityHostingStartup))]
namespace Prj_CarPool.Areas.Identity
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