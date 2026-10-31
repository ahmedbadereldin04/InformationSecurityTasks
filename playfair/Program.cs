class Program
{
    static void Main()
    {
        while (true)
        {
            string abc = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

            Console.Write("Key: ");
            string key = (Console.ReadLine() ?? "").ToUpper().Replace("J", "I");

            Console.Write("Text: ");
            string text = (Console.ReadLine() ?? "").ToUpper().Replace("J", "I");

            Console.Write("Encrypt (E) or Decrypt (D)? ");
            string mode = (Console.ReadLine() ?? "E").ToUpper();

            if (mode != "E" && mode != "D")
            {
                Console.WriteLine("Invalid Mode!\n");
                continue;
            }

            string m = "";

            foreach (char c in key + abc)
                if (abc.Contains(c) && !m.Contains(c))
                    m += c;

            string t = "";

            foreach (char c in text)
                if (abc.Contains(c))
                    t += c;

            string result = "";

            if (mode == "E")
            {
                for (int i = 0; i < t.Length; i++)
                {
                    char a = t[i];

                    char b = (i + 1 < t.Length && t[i + 1] != a)
                        ? t[++i] : 'X';

                    int p1 = m.IndexOf(a);
                    int p2 = m.IndexOf(b);

                    int r1 = p1 / 5, c1 = p1 % 5;
                    int r2 = p2 / 5, c2 = p2 % 5;

                    if (r1 == r2)
                    {
                        result += m[r1 * 5 + (c1 + 1) % 5];
                        result += m[r2 * 5 + (c2 + 1) % 5];
                    }
                    else if (c1 == c2)
                    {
                        result += m[((r1 + 1) % 5) * 5 + c1];
                        result += m[((r2 + 1) % 5) * 5 + c2];
                    }
                    else
                    {
                        result += m[r1 * 5 + c2];
                        result += m[r2 * 5 + c1];
                    }
                }
            }
            else
            {
                if (t.Length % 2 != 0)
                {
                    Console.WriteLine("Invalid Text! Ciphertext must have even length.\n");
                    continue;
                }

                for (int i = 0; i < t.Length; i += 2)
                {
                    char a = t[i];
                    char b = t[i + 1];

                    int p1 = m.IndexOf(a);
                    int p2 = m.IndexOf(b);

                    int r1 = p1 / 5, c1 = p1 % 5;
                    int r2 = p2 / 5, c2 = p2 % 5;

                    if (r1 == r2)
                    {
                        result += m[r1 * 5 + (c1 + 4) % 5];
                        result += m[r2 * 5 + (c2 + 4) % 5];
                    }
                    else if (c1 == c2)
                    {
                        result += m[((r1 + 4) % 5) * 5 + c1];
                        result += m[((r2 + 4) % 5) * 5 + c2];
                    }
                    else
                    {
                        result += m[r1 * 5 + c2];
                        result += m[r2 * 5 + c1];
                    }
                }
            }

            Console.WriteLine($"Result: {result}\n");
        }
    }
}
