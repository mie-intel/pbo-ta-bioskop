namespace PBO_IOUtils
{
    public class IOUtil
    {
        public static string GetLine(string question)
        {
            Console.Write(question);
            string inp = Console.ReadLine() ?? "";
            return inp;
        }

        public static int GetInt(string question)
        {
            Console.Write(question);
            string inp = Console.ReadLine() ?? "";
            if (int.TryParse(inp, out int result))
                return int.Parse(inp);
            return -1;
        }

        public static void WriteParagraph(string paragraph, int tab = 4, int limit = 50)
        {
            var listKalimat = paragraph.Split(" ");
            int kalimatLength = 4;
            char last = ' ';
            // print tab
            Console.Write(new string(' ', tab));
            for (int i = 0; i < listKalimat.Length; )
            {
                if (kalimatLength + listKalimat[i].Length + (last != ' ' ? 1 : 0) <= limit)
                {
                    // lanjut kalimat sekarang
                    if (last != ' ')
                        Console.Write(" ");
                    Console.Write(listKalimat[i]);
                    // update panjang kalimat
                    kalimatLength += listKalimat[i].Length + (last != ' ' ? 1 : 0);
                    last = listKalimat[i][listKalimat[i].Length - 1];
                    ++i;
                }
                else
                {
                    // pindah kalimat bawah
                    last = ' ';
                    Console.WriteLine();
                    kalimatLength = 0;
                }
            }

            return;
        }
    }
}
