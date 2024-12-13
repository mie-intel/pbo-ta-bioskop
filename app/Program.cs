using PBO_GUI;

namespace app
{
    internal class Program
    {
        // Program Utama
        static void Main(string[] args)
        {
            // 1. login dulu
            //      kalo gagal, return null
            //      kalo berhasil, lanjut
            // kalo gagal login / register -> return

            // program utama
            while (true)
            {
                // kalo terminal display return false, langsung break
                if (!TerminalDisplay.Display())
                    break;
            }

            Console.WriteLine("\nSampai Jumpa!");
        }
    }
}
