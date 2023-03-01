using Microsoft.AspNetCore.Http;
using PDP_Edu.Application.Models;

namespace PDP_Edu.Application.Abstractions
{
    public interface IProfileService
    {
        Task SetPhoto(IFormFile formFile);
        Task<ProfileViewModel> GetProfile();
    }
}
