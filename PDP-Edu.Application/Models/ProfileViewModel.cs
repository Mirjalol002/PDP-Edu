using PDP_Edu.Application.Models.Group;

namespace PDP_Edu.Application.Models
{
    public class ProfileViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhotoPath { get; set; } = string.Empty;

        public ICollection<GroupViewModel> Groups { get; set; }
    }
}
