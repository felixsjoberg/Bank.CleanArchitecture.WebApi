using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApplication.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankApplication.Api.Controllers
{
    [Route("admin/accounts")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountsController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListAccounts()
        {
            return Ok();
        }
    }
}
