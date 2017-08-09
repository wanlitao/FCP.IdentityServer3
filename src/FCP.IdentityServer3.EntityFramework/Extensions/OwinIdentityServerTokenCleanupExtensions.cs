using IdentityServer3.EntityFramework;
using Microsoft.Owin.BuilderProperties;
using Owin;
using System.Threading.Tasks;

namespace FCP.IdentityServer3.EntityFramework
{
    public static class OwinIdentityServerTokenCleanupExtensions
    {
        public static IAppBuilder UseIdentityServerTokenCleanup(this IAppBuilder app, EntityFrameworkServiceOptions options, int interval)
        {
            var appProperties = new AppProperties(app.Properties);
            var cancellationToken = appProperties.OnAppDisposing;

            var cleanup = new TokenCleanup(options, interval);
            Task.Factory.StartNew(() => cleanup.Start(cancellationToken));

            return app;
        }
    }
}
