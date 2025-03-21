using Microsoft.AspNetCore.Http;

namespace EpicVision.Application_BLL.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveHallImageAsync(IFormFile file);
    }
}
