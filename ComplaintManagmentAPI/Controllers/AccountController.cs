using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ComplaintManagmentAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintManagmentAPI.Controllers
{
    [ApiController]
    [Route("[controller]/v1")]
    public class AccountController : ControllerBase
    {
        private IUSer _user;
        public AccountController(IUSer user)
        {
            _user = user;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Get(Models.User obj)
        {
            var result = await _user.GetBy(obj);
            return Ok(new
            {
                status = (int)HttpStatusCode.OK,
                data = result
            });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Models.User obj)
        {

            var result = await _user.Insert(obj);
            return Ok(new
            {
                status = (int)HttpStatusCode.OK,
                data = result
            });
        }
    }
}