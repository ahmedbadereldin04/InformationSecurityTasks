class Program
{
    static void Main()
    {
        while (true)
        {
            string abc = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Console.Write("Text: ");
            string text = (Console.ReadLine() ?? "").ToUpper();

            Console.Write("Key: ");
            string key = (Console.ReadLine() ?? "").ToUpper();

            Console.Write("Encrypt (E) or Decrypt (D)? ");
            string mode = (Console.ReadLine() ?? "E").ToUpper();

            if (key.Length != text.Length)
            {
                Console.WriteLine("Key must have same length as Text!\n");
                continue;
            }

            if (mode != "E" && mode != "D")
            {
                Console.WriteLine("Invalid Mode!\n");
                continue;
            }

            string result = "";

            for (int i = 0; i < text.Length; i++)
            {
                int t = abc.IndexOf(text[i]);
                int k = abc.IndexOf(key[i]);

                if (t == -1 || k == -1)
                {
                    Console.WriteLine("Invalid Text or Key!\n");
                    result = "";
                    break;
                }

                int x;

                if (mode == "E")
                    x = (t + k) % 26;
                else
                    x = (t - k + 26) % 26;

                result += abc[x];
            }

            if (result != "")
                Console.WriteLine($"Result: {result}\n");
        }
    }
}
