using PDP_Edu.Application.Models;
using PDP_Edu.Application.Models.Group;

namespace PDP_Edu.Application.Abstractions
{
    public interface IGroupService : ICrudService<int, GroupViewModel, CreateGroupModel, UpdateGroupModel>
    {
        Task<List<LessonViewModel>> GetLessonAsync(int groupId);
        Task AddStudentAsync(AddStudentGroupModel model, int groupId);
        Task RemoveStudentAsync(int studentId, int groupId);
    }
}


