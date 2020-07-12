
namespace SqlServerDbApp.Models
{
    public class User : Entity
    {
        public string Nickname { get; set; } 
        public string BlogTitle { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
