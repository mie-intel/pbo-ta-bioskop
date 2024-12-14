using System.ComponentModel.DataAnnotations.Schema;

namespace App.Model
{
    [Table("Users")]
    public class UserModel
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
