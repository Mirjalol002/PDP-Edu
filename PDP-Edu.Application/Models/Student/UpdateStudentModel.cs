namespace PDP_Edu.Application.Models.Student
{
    public class UpdateStudentModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
