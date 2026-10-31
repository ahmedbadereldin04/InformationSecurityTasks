class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Text: ");
            string text = (Console.ReadLine() ?? "").ToUpper();

            Console.Write("Key: ");
            string key = (Console.ReadLine() ?? "").ToUpper();

            Console.Write("Encrypt (E) or Decrypt (D)? ");
            string mode = (Console.ReadLine() ?? "E").ToUpper();

            if (key.Length == 0 || text.Length == 0)
            {
                Console.WriteLine("Invalid Key or Text!\n");
                continue;
            }

            if (mode != "E" && mode != "D")
            {
                Console.WriteLine("Invalid Mode!\n");
                continue;
            }

            int cols = key.Length;
            int rows = (int)Math.Ceiling((double)text.Length / cols);

            int[] order = Enumerable.Range(0, cols)
                .OrderBy(i => key[i])
                .ThenBy(i => i)
                .ToArray();

            char[,] grid = new char[rows, cols];

            string result = "";

            if (mode == "E")
            {
                string padded = text.PadRight(rows * cols, 'X');

                for (int i = 0; i < padded.Length; i++)
                    grid[i / cols, i % cols] = padded[i];

                foreach (int c in order)
                    for (int r = 0; r < rows; r++)
                        result += grid[r, c];
            }
            else
            {
                int k = 0;

                foreach (int c in order)
                    for (int r = 0; r < rows; r++)
                        if (k < text.Length)
                            grid[r, c] = text[k++];

                for (int r = 0; r < rows; r++)
                    for (int c = 0; c < cols; c++)
                        result += grid[r, c];
            }

            Console.WriteLine($"Result: {result}\n");
        }
    }
}
