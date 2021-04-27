using System.Collections.Generic;

using DS.Common.Entities;
using DS.Services.Common.Parameters;

namespace DS.Services.Interface
{
    public interface IRoleService
    {
        IEnumerable<dynamic> GetRoles(BaseQuery query);
        
        int SetRole(Role role);

        int DeleteRole(Role role);

        IEnumerable<dynamic> GetRoleApps(BaseQuery query);

        int SetRoleApp(RoleApp app);

        int DeleteRoleApp(RoleApp app);

    }
}