namespace App.Utils
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
    }
}
