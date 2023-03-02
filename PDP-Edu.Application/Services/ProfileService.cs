using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models;
using PDP_Edu.Application.Models.Group;

namespace PDP_Edu.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IFileService _fileService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IApplicationDbContext _applicationDbContext;
        public ProfileService(IFileService fileService, ICurrentUserService currentUserService, IApplicationDbContext applicationDbContext)
        {
            _fileService = fileService;
            _currentUserService = currentUserService;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<ProfileViewModel> GetProfile()
        {
            var userId = _currentUserService.UserId;
            var user = await _applicationDbContext.Users.Include(x => x.Groups).FirstOrDefaultAsync(x => x.Id == userId);

            return new ProfileViewModel()
            {
                UserName = user!.UserName,
                FullName = user.FullName,
                PhotoPath = user.PhotoPath,
                Groups = new List<GroupViewModel>(user.Groups.Select(x => new GroupViewModel()
                {
                    Id = x.Id,
                    TeacherId = x.TeacherId,
                    Name = x.Name,
                    StartedDate = x.StartDate,
                    EndDate = x.EndDate
                }))
            };
        }

        public async Task SetPhoto(IFormFile formFile)
        {
            var userId = _currentUserService.UserId;
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var path = await _fileService.Upload(formFile);
            user.PhotoPath = path;

            _applicationDbContext.Users.Update(user);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
