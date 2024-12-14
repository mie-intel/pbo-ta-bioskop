namespace App.Model
{
    [Table("Films")]
    public class FilmModel
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Tanggal { get; set; }
        public int Rate { get; set; }
        public int Harga { get; set; }
        public string Seat { get; set; }
        public string Deskripsi { get; set; }
    }
}
