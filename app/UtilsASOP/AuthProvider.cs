namespace App.Utils
{
    public class AuthProvider
    {
        public static bool HandleLogin()
        {
            Console.Clear();
            Console.WriteLine("Selamat datang di halaman Login!\n");
            Console.WriteLine("Silahkan masukkan Username dan Password anda.");
            Console.Write("Username: ");
            string username = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Password: ");
            string password = Console.ReadLine()?.Trim() ?? "";

            // menggunakan UserProvider.Login
            string loginResult = UserProvider.LogIn(username, password);
            if (loginResult == "success")
            {
                Console.WriteLine("\nLogin berhasil!");
                // Console.WriteLine($"Selamat datang, {UserProvider.GetUsername()}!");
                return true;
            }
            else
            {
                Console.WriteLine("\nLogin gagal!");
                return false;
            }
        }

        public static bool HandleRegister()
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
                return false;
            }

            // Panggil fungsi UserProvider.Register
            string registerResult = UserProvider.Register(username, password);

            if (registerResult == "success")
                Console.WriteLine("\nRegistrasi berhasil! Silakan login kembali.");
            else if (registerResult == "user-exist")
                Console.WriteLine("\nAkun sudah terdaftar! Silakan buat akun lain.");
            else
                Console.WriteLine("\nTerjadi kesalahan saat registrasi. Silakan coba lagi.");
            return false;
        }
    }
}
