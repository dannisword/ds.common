using System;
using Microsoft.AspNetCore.Mvc;

using DS.Common.Entities;
using DS.Services.Interface;
using DS.Services.Common.Parameters;

namespace DS.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AppController : ControllerBase
    {
        public IAppService AppService { get; private set; }

        public AppController(IAppService appService)
        {
            this.AppService = appService;
        }
        #region AppStore

        [HttpPost]
        public IActionResult GetAppStores(BaseQuery query)
        {
            return this.Ok(this.AppService.GetAppStores(query));
        }

        [HttpPost]
        public IActionResult SetAppStore(AppStore app)
        {
            return this.Ok(this.AppService.SetAppStore(app));
        }

        [HttpDelete]
        public IActionResult DeleteAppStore(AppStore user)
        {
            //return this.Ok(this.UserService.DeleteUserAccount(user));
            return this.Ok(1);
        }

        #endregion
    }
}