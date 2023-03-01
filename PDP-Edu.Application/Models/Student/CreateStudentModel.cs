using System.ComponentModel.DataAnnotations;

namespace PDP_Edu.Application.Models.Student
{
    public class CreateStudentModel
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}