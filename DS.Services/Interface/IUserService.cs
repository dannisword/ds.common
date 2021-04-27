using System.Collections.Generic;

using DS.Common.Entities;
using DS.Services.Common.Parameters;
using DS.Services.Infrastructure;

namespace DS.Services.Interface
{
    public interface IUserService //: IBaseService<UserAccount>
    {
        IEnumerable<dynamic> GetUserAccounts(UserQuery query);

        int SetUserAccount(UserAccount user);

        int DeleteUserAccount(UserAccount user);

        IEnumerable<dynamic> GetUserRoles(BaseQuery query);

        int SetUserRole(UserRole role);

        int DeleteUserRole(UserRole role);
    }
}