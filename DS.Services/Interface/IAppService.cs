using System.Collections.Generic;

using DS.Common.Entities;
using DS.Services.Common.Parameters;

namespace DS.Services.Interface
{
    public interface IAppService
    {
        IEnumerable<dynamic> GetAppStores(BaseQuery query);
        
        int SetAppStore(AppStore app);

        //int DeleteAppStore(T app);
    }
}