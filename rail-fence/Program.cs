class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Text: ");
            string text = (Console.ReadLine() ?? "").ToUpper();

            Console.Write("Key: ");
            if (!int.TryParse(Console.ReadLine(), out int key) || key < 2)
            {
                Console.WriteLine("Invalid Key!\n");
                continue;
            }

            Console.Write("Encrypt (E) or Decrypt (D)? ");
            string mode = (Console.ReadLine() ?? "E").ToUpper();

            if (mode != "E" && mode != "D")
            {
                Console.WriteLine("Invalid Mode!\n");
                continue;
            }

            int rows = key;
            int cols = text.Length;

            char[,] grid = new char[rows, cols];

            string result = "";

            if (mode == "E")
            {
                int r = 0;
                int dir = 1;

                for (int i = 0; i < text.Length; i++)
                {
                    grid[r, i] = text[i];

                    if (r == 0)
                        dir = 1;
                    else if (r == key - 1)
                        dir = -1;

                    r += dir;
                }

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (grid[i, j] != '\0')
                            result += grid[i, j];
            }
            else
            {
                int r = 0;
                int dir = 1;

                for (int i = 0; i < text.Length; i++)
                {
                    grid[r, i] = '*';

                    if (r == 0)
                        dir = 1;
                    else if (r == key - 1)
                        dir = -1;

                    r += dir;
                }

                int k = 0;

                for (int i = 0; i < rows; i++)
                    for (int j = 0; j < cols; j++)
                        if (grid[i, j] == '*')
                            grid[i, j] = text[k++];

                r = 0;
                dir = 1;

                for (int i = 0; i < text.Length; i++)
                {
                    result += grid[r, i];

                    if (r == 0)
                        dir = 1;
                    else if (r == key - 1)
                        dir = -1;

                    r += dir;
                }
            }

            Console.WriteLine($"Result: {result}\n");
        }
    }
}
