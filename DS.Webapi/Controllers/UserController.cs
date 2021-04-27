using System;
using Microsoft.AspNetCore.Mvc;

using DS.Common.Entities;
using DS.Services.Interface;
using DS.Services.Common.Parameters;

namespace DS.Webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        public IUserService UserService { get; private set; }

        public UserController(IUserService userService)
        {
            this.UserService = userService;
        }
        #region UserAcount

        [HttpPost]
        public IActionResult GetUserAccount(UserQuery query)
        {
            return this.Ok(this.UserService.GetUserAccounts(query));
        }

        [HttpPost]
        public IActionResult SetUserAccount(UserAccount user)
        {
            return this.Ok(this.UserService.SetUserAccount(user));
        }

        [HttpDelete]
        public IActionResult DeleteUserAccount(UserAccount user)
        {
            return this.Ok(this.UserService.DeleteUserAccount(user));
        }

        #endregion

        #region UserRole

        [HttpPost]
        public IActionResult GetUserRoles(BaseQuery query)
        {
            return this.Ok(this.UserService.GetUserRoles(query));
        }

        [HttpPost]
        public IActionResult SetUserRole(UserRole role)
        {
            return this.Ok(this.UserService.SetUserRole(role));
        }

        [HttpDelete]
        public IActionResult DeleteUserRole(UserRole role)
        {
            return this.Ok(this.UserService.DeleteUserRole(role));
        }

        #endregion

    }
}