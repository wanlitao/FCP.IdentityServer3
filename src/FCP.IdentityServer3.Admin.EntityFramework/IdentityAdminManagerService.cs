using IdentityServer3.Admin.EntityFramework;
using IdentityServer3.Admin.EntityFramework.Entities;

namespace FCP.IdentityServer3.Admin.EntityFramework
{
    public class IdentityAdminManagerService : IdentityAdminCoreManager<IdentityClient, int, IdentityScope, int>
    {
        public IdentityAdminManagerService(string connectionString, string schema = null)
            : base(connectionString, schema)
        { }
    }
}
