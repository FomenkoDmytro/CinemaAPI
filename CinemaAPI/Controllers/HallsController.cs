using Microsoft.AspNetCore.Mvc;
using EpicVision.Application_BLL.Interfaces;


namespace CinemaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class HallsController : Controller
    {
        private readonly IFileService _fileService;

        public HallsController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            try
            {
                string fileUrl = await _fileService.SaveHallImageAsync(file);
                return Ok(new { url = fileUrl });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
