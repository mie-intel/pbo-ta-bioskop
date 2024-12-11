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

            // program utama
            while (true)
            {
                bool lanjut = TerminalDisplay.Display();
                if (!lanjut)
                    break;
            }
        }
    }
}
