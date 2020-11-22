using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timebox.Account.Api.DTOs;
using Timebox.Account.Application.DTOs;
using Timebox.Account.Application.Interfaces.Services;

namespace Timebox.Account.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        
        [HttpPost]
        public async Task<JsonResult> CreateAccount([FromBody] CreateAccountDTO createAccountDto)
        {
            return AccountCreatedDTO.FromEntity(await _accountService.CreateAccountAsync(createAccountDto)).ToJsonResult();
        }
    }
}