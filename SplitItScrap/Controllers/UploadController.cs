using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SplitItScrap.Domain.Services.Uploads;
using System.Threading.Tasks;

namespace SplitItScrap.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IUploadService _uploadService;

        public UploadController(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }

        [HttpGet("actors")]
        public async Task<IActionResult> PullActorsAsync()
        {
            await _uploadService.HandleActorsAsync();

            return Ok();
        }
    }
}
