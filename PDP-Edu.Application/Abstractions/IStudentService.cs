using PDP_Edu.Application.Models;

namespace PDP_Edu.Application.Abstractions
{
    public interface IStudentService
    {
        Task<LessonViewModel> GetAllAsync(LessonViewModel model);

    }
}
