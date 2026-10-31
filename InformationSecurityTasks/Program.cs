class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter text: ");
            string text = Console.ReadLine() ?? "";

            Console.Write("Enter key: ");
            if (!int.TryParse(Console.ReadLine(), out int key))
            {
                Console.WriteLine("Invalid key!\n");
                continue;
            }

            Console.Write("Encrypt (E) or Decrypt (D)? ");
            string mode = (Console.ReadLine() ?? "E").ToUpper();

            int shift = (mode == "D") ? -key : key;

            shift = ((shift % 26) + 26) % 26;

            string result = "";


            foreach (char c in text)
            {
                if (char.IsUpper(c))
                    result += (char)((c - 'A' + shift) % 26 + 'A');
                else if (char.IsLower(c))
                    result += (char)((c - 'a' + shift) % 26 + 'a');
                else
                    result += c;
            }

            Console.WriteLine($"Result: {result}\n");
        }
    }
}
