using Microsoft.AspNetCore.Http;

namespace PDP_Edu.Application.Abstractions
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile fromFile);
    }
}
