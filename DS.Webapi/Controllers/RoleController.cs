using System;
using Microsoft.AspNetCore.Mvc;

using DS.Common.Entities;
using DS.Services.Interface;
using DS.Services.Common.Parameters;

namespace DS.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RoleController : ControllerBase
    {
        public IRoleService RoleService { get; private set; }

        public RoleController(IRoleService roleService)
        {
            this.RoleService = roleService;
        }
        #region RoleApp

        [HttpPost]
        public IActionResult GetUserAccount(UserQuery query)
        {
            //return this.Ok(this.UserService.GetUserAccounts(query));

            return this.Ok(1);
        }

        [HttpPost]
        public IActionResult SetRoleApp(RoleApp app)
        {
            return this.Ok(this.RoleService.SetRoleApp(app));
        }

        [HttpDelete]
        public IActionResult DeleteUserAccount(UserAccount user)
        {
            //return this.Ok(this.UserService.DeleteUserAccount(user));
            return this.Ok(1);
        }

        #endregion
    }
}