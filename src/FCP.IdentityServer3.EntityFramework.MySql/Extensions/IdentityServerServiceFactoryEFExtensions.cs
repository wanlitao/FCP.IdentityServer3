using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;
using System.Collections.Generic;

namespace FCP.IdentityServer3.EntityFramework.MySql
{
    public static class IdentityServerServiceFactoryEFExtensions
    {
        public static IdentityServerServiceFactory UseEFConfigurationByMySql(this IdentityServerServiceFactory factory,
            EntityFrameworkServiceOptions options)
        {
            return UseEFConfigurationByMySql(factory, options, null);
        }

        public static IdentityServerServiceFactory UseEFConfigurationByMySql(this IdentityServerServiceFactory factory,
            EntityFrameworkServiceOptions options, IEnumerable<Client> clients, params Scope[] scopes)
        {
            DbConfigurationExtensions.UseMySql();

            return factory.UseEFConfiguration(options, clients, scopes);
        }

        public static IdentityServerServiceFactory UseEFOperationalByMySql(this IdentityServerServiceFactory factory,
            EntityFrameworkServiceOptions options)
        {
            DbConfigurationExtensions.UseMySql();

            return factory.UseEFOperational(options);
        }
    }
}
