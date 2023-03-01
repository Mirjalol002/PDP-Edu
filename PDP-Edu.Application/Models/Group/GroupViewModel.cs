namespace PDP_Edu.Application.Models.Group
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}