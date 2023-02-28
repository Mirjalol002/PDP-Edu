namespace PDP_Edu.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public int LessonId { get; set; }
        public bool HasParticipated { get; set; }

        public Student Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
