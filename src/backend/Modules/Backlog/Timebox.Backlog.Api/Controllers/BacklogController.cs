using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Timebox.Backlog.Application.Dtos;
using Timebox.Backlog.Application.Services;

namespace Timebox.Backlog.Api.Controllers
{
    [Route("api/[Controller]")]
    public class BacklogController : ControllerBase
    {
        private readonly IBacklogService _backlogService;

        public BacklogController(IBacklogService backlogService)
        {
            _backlogService = backlogService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBacklogAsync([FromBody] CreateBacklogDto dto)
        {
            await _backlogService.CreateAsync(dto);
            return Ok();
        }
    }
}