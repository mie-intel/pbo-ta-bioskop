using System.ComponentModel.DataAnnotations.Schema;

namespace App.Model
{
    [Table("Films")]
    public class FilmModel
    {
        public int Id { get; set; }
        public required string Nama { get; set; }
        public required string Tanggal { get; set; }
        public required int Rate { get; set; }
        public required int Harga { get; set; }
        public required string Seat { get; set; }
        public required string Deskripsi { get; set; }
    }
}
