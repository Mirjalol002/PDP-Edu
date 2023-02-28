using PDP_Edu.Domain.Enums;

namespace PDP_Edu.Domain.Entities
{
    public class User
    {
        public User()
        {
            Groups = new HashSet<Group>();
        }
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }

        public string PhotoPath { get; set; } = string.Empty;

        public ICollection<Group> Groups { get; set; }
    }
}
