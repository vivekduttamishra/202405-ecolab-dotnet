namespace BooksWebV2.Models
{
    public class RoleInfo
    {
        public List<string> AddRoles { get; set; } = new List<string>();
        public List<string> RemoveRoles { get; set; } = new List<string>();
    }
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserInfo
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public string? Name { get; set; }

        public string? ProfilePicture { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

    }


}
