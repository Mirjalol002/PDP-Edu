using PDP_Edu.Application.Models.Teacher;

namespace PDP_Edu.Application.Abstractions
{
    public interface ITeacherService : ICrudService<int, TeacherViewModel, CreateTeacherModel, UpdateTeacherModel>
    {
    }
}
