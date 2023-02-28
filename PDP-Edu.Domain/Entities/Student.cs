namespace PDP_Edu.Domain.Entities
{
    public class Student
    {
        public Student()
        {
            StudentGroups = new HashSet<StudentGroup>();
            Attendances = new HashSet<Attendance>();
        }
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;

        public ICollection<StudentGroup> StudentGroups { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
