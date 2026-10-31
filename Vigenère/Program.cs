class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine() ?? "";

            Console.Write("Enter key (word): ");
            string key = (Console.ReadLine() ?? "").ToUpper();

            string cleanKey = "";
            foreach (char c in key)
                if (char.IsLetter(c)) cleanKey += c;

            if (cleanKey.Length == 0)
            {
                Console.WriteLine("Invalid key! Must contain letters.\n");
                continue;
            }

            Console.Write("Encrypt (E) or Decrypt (D)? ");
            string mode = (Console.ReadLine() ?? "E").ToUpper();

            int sign = (mode == "D") ? -1 : 1;

            string result = "";
            int keyIndex = 0;

            foreach (char c in text)
            {
                if (char.IsUpper(c))
                {
                    int shift = (cleanKey[keyIndex % cleanKey.Length] - 'A') * sign;
                    shift = ((shift % 26) + 26) % 26;
                    result += (char)('A' + (c - 'A' + shift) % 26);
                    keyIndex++;
                }
                else if (char.IsLower(c))
                {
                    int shift = (cleanKey[keyIndex % cleanKey.Length] - 'A') * sign;
                    shift = ((shift % 26) + 26) % 26;
                    result += (char)('a' + (c - 'a' + shift) % 26);
                    keyIndex++;
                }
                else
                    result += c;
            }

            Console.WriteLine($"Result: {result}\n");
        }
    }
}