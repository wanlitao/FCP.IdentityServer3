using FCP.Util;
using IdentityAdmin.Configuration;
using IdentityAdmin.Core;
using System;

namespace FCP.IdentityServer3.Admin.EntityFramework
{
    public static class IdentityAdminServiceFactoryEFExtensions
    {
        public static IdentityAdminServiceFactory UseEFAdmin(this IdentityAdminServiceFactory factory, string connectionString, string schema = null)
        {
            if (connectionString.isNullOrEmpty())
                throw new ArgumentNullException(nameof(connectionString));

            factory.IdentityAdminService = new Registration<IIdentityAdminService>(
                (dependencyResolver) => new IdentityAdminManagerService(connectionString, schema));

            return factory;
        }
    }
}
