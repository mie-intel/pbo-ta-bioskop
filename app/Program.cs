using System.Runtime.CompilerServices;
using App.Utils;
using Microsoft.EntityFrameworkCore;
using PBO_GUI;

namespace App
{
    internal class Program
    {
        // Program Utama
        static void Main(string[] args)
        {
            // // string tes = UserProvider.Register("polikarpu123", "mie-mie");
            // // Console.WriteLine(tes);
            // // Console.WriteLine(FilmProvider.GenerateSeatCode(3));
            // FilmProvider.AddFilm("Ipar adalah maut", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            // FilmProvider.AddFilm("Ipar2", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            // FilmProvider.AddFilm("Ipar3", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            // FilmProvider.AddFilm("Ipar4", "23/12/2024", 5, 1000, 10, "Aku makan teri");
            // var Seat = FilmProvider.ParseSeat("FPeT3G1");
            // // Console.WriteLine(Seat);
            // foreach (var p in Seat)
            // {
            //     Console.WriteLine(p.Item1 + " " + p.Item2);
            // }
            while (true)
            {
                if (!TerminalDisplay.Display())
                    break;
            }
            Console.WriteLine("\nSampai Jumpa!");
        }

        public static void Login()
        {
            Console.Clear();
            Console.WriteLine("Selamat datang di halaman Login!\n");
            Console.WriteLine("Silahkan masukkan Username dan Password anda.");
            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            // pake UserProvider.Login
            string loginResult = UserProvider.LogIn(username, password);
            if (loginResult == "success")
            {
                Console.WriteLine("Login berhasil!");
                Console.WriteLine($"Selamat datang, {UserProvider.GetUsername()}!");
            }
            else
            {
                Console.WriteLine("Login gagal!");
            }
        }

        public static void Register()
        {
            Console.Clear();
            Console.WriteLine("Selamat datang di halaman Registrasi!\n");
            // Ambil input username dan password dari pengguna
            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? ""; // Trim untuk menghapus spasi tambahan
            Console.Write("Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            // Validasi input
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Username dan password tidak boleh kosong!");
                return;
            }

            // Panggil fungsi UserProvider.Register
            string registerResult = UserProvider.Register(username, password);

            if (registerResult == "success")
            {
                Console.WriteLine("Registrasi berhasil! Anda dapat login sekarang.");
            }
            else if (registerResult == "user-exist")
            {
                Console.WriteLine("Username sudah terdaftar! Silakan gunakan username lain.");
            }
            else
            {
                Console.WriteLine("Terjadi kesalahan saat registrasi. Silakan coba lagi.");
            }
        }
    }
}
