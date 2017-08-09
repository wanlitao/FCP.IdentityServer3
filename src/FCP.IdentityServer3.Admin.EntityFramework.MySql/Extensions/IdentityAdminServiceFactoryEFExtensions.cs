using FCP.IdentityServer3.EntityFramework.MySql;
using IdentityAdmin.Configuration;

namespace FCP.IdentityServer3.Admin.EntityFramework.MySql
{
    public static class IdentityAdminServiceFactoryEFExtensions
    {
        public static IdentityAdminServiceFactory UseEFAdminByMySql(this IdentityAdminServiceFactory factory, string connectionString, string schema = null)
        {
            DbConfigurationExtensions.UseMySql();

            return factory.UseEFAdmin(connectionString, schema);
        }
    }
}
