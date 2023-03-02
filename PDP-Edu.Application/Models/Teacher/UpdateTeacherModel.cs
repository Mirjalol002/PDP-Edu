using System.ComponentModel.DataAnnotations;

namespace PDP_Edu.Application.Models.Teacher
{
    public class UpdateTeacherModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
