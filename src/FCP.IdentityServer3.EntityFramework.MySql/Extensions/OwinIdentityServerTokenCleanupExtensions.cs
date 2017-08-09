using IdentityServer3.EntityFramework;
using Owin;

namespace FCP.IdentityServer3.EntityFramework.MySql
{
    public static class OwinIdentityServerTokenCleanupExtensions
    {
        public static IAppBuilder UseIdentityServerTokenCleanupByMySql(this IAppBuilder app, EntityFrameworkServiceOptions options, int interval)
        {
            DbConfigurationExtensions.UseMySql();

            return app.UseIdentityServerTokenCleanup(options, interval);
        }
    }
}
