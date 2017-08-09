using FCP.MySql.Data.Entity;
using System.Data.Entity;

namespace FCP.IdentityServer3.EntityFramework.MySql
{
    public static class DbConfigurationExtensions
    {
        private static readonly DbConfiguration _mysqlDbConfiguration = new MySqlEFDbConfiguration();

        public static void UseMySql()
        {
            DbConfiguration.SetConfiguration(_mysqlDbConfiguration);
        }
    }
}
