using PDP_Edu.Application.Models.Student;

namespace PDP_Edu.Application.Abstractions
{
    public interface IStudentService : ICrudService<int, StudentViewModel, CreateStudentModel, UpdateStudentModel>
    {
    }
}