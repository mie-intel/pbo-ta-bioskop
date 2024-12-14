using System.ComponentModel.DataAnnotations.Schema;

namespace App.Model
{
    [Table("Users")]
    public class UserModel
    {
        public required string Id { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
