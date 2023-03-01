using PDP_Edu.Application.Models;

namespace PDP_Edu.Application.Abstractions
{
    public interface IAttendanceService
    {
        Task CheckAsync(DoAttendanceCheckModel model);
    }
}
