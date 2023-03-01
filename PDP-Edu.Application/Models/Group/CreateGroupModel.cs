namespace PDP_Edu.Application.Models.Group
{
    public class CreateGroupModel
    {
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public DateOnly StartedDate { get; set; }
        public DateOnly EndDate { get; set; }
        public TimeSpan LessonStartTime { get; set; }
        public TimeSpan LessonEndTime { get; set; }
    }
}