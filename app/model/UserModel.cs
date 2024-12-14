namespace App.Model
{
    [Table("Users")]
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    // EF Core DbContext


    // // EF Core Entity (Model)
    // public class Product
    // {
    //     public int Id { get; set; }
    //     public string Name { get; set; }
    //     public decimal Price { get; set; }
    // }
}
}
