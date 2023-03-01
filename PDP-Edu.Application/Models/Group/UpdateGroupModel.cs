namespace PDP_Edu.Application.Models.Group
{
    public class UpdateGroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TeacherId { get; set; }
    }
}
