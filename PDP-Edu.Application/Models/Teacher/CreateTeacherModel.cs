using System.ComponentModel.DataAnnotations;

namespace PDP_Edu.Application.Models.Teacher
{
    public class CreateTeacherModel
    {
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}