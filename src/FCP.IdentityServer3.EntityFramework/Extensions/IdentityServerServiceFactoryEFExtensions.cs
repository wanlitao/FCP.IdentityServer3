using FCP.Util;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace FCP.IdentityServer3.EntityFramework
{
    public static class IdentityServerServiceFactoryEFExtensions
    {
        #region Configuration
        public static IdentityServerServiceFactory UseEFConfiguration(this IdentityServerServiceFactory factory,
            EntityFrameworkServiceOptions options)
        {
            return UseEFConfiguration(factory, options, null);
        }

        public static IdentityServerServiceFactory UseEFConfiguration(this IdentityServerServiceFactory factory,
            EntityFrameworkServiceOptions options, IEnumerable<Client> clients, params Scope[] scopes)
        {
            factory.RegisterConfigurationServices(options);

            ConfigureInitialClients(options, clients?.ToArray());
            ConfigureInitialScopes(options, scopes);

            return factory;
        }

        #region Initial Configuration
        private static void ConfigureInitialClients(EntityFrameworkServiceOptions options, params Client[] clients)
        {
            if (clients.isEmpty())
                return;

            using (var db = new ClientConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                if (!db.Clients.Any())
                {
                    foreach (var client in clients)
                    {
                        var entity = client.ToEntity();
                        db.Clients.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
        }

        private static void ConfigureInitialScopes(EntityFrameworkServiceOptions options, params Scope[] scopes)
        {
            if (scopes.isEmpty())
                return;

            using (var db = new ScopeConfigurationDbContext(options.ConnectionString, options.Schema))
            {
                if (!db.Scopes.Any())
                {
                    foreach (var scope in scopes)
                    {
                        var entity = scope.ToEntity();
                        db.Scopes.Add(entity);
                    }
                    db.SaveChanges();
                }
            }
        }
        #endregion

        #endregion

        public static IdentityServerServiceFactory UseEFOperational(this IdentityServerServiceFactory factory,
            EntityFrameworkServiceOptions options)
        {
            factory.RegisterOperationalServices(options);

            return factory;
        }
    }
}
