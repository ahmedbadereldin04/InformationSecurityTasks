class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Matrix Size (2 or 3): ");
            if (!int.TryParse(Console.ReadLine(), out int size) ||
                (size != 2 && size != 3))
            {
                Console.WriteLine("Invalid Size!\n");
                continue;
            }

            int[,] key = new int[size, size];

            Console.WriteLine("Enter Key Matrix:");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write("Key[" + i + "," + j + "]: ");

                    if (!int.TryParse(Console.ReadLine(), out key[i, j]))
                    {
                        Console.WriteLine("Invalid Key!\n");
                        i = -1;
                        break;
                    }
                }
            }

            Console.Write("Text: ");
            string text = (Console.ReadLine() ?? "").ToUpper();

            Console.Write("Encrypt (E) or Decrypt (D)? ");
            string mode = (Console.ReadLine() ?? "E").ToUpper();

            if (mode != "E" && mode != "D")
            {
                Console.WriteLine("Invalid Mode!\n");
                continue;
            }

            string clean = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= 'A' && text[i] <= 'Z')
                    clean += text[i];
            }

            while (clean.Length % size != 0)
                clean += "X";

            int[,] matrix = new int[size, size];

            if (mode == "E")
            {
                matrix = key;
            }
            else
            {
                int det = 0;

                if (size == 2)
                {
                    det = key[0, 0] * key[1, 1]
                        - key[0, 1] * key[1, 0];
                }
                else
                {
                    det =
                        key[0, 0] * (key[1, 1] * key[2, 2] - key[1, 2] * key[2, 1])
                      - key[0, 1] * (key[1, 0] * key[2, 2] - key[1, 2] * key[2, 0])
                      + key[0, 2] * (key[1, 0] * key[2, 1] - key[1, 1] * key[2, 0]);
                }

                det = ((det % 26) + 26) % 26;

                int detInv = -1;

                for (int i = 1; i < 26; i++)
                {
                    if ((det * i) % 26 == 1)
                    {
                        detInv = i;
                        break;
                    }
                }

                if (detInv == -1)
                {
                    Console.WriteLine("Invalid Key Matrix!\n");
                    continue;
                }

                if (size == 2)
                {
                    matrix[0, 0] = key[1, 1];
                    matrix[0, 1] = -key[0, 1];
                    matrix[1, 0] = -key[1, 0];
                    matrix[1, 1] = key[0, 0];

                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            matrix[i, j] =
                                ((matrix[i, j] * detInv % 26) + 26) % 26;
                        }
                    }
                }
                else
                {
                    for (int r = 0; r < 3; r++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            int r1 = (r + 1) % 3;
                            int r2 = (r + 2) % 3;
                            int c1 = (c + 1) % 3;
                            int c2 = (c + 2) % 3;

                            int cofactor =
                                key[c1, r1] * key[c2, r2]
                                - key[c1, r2] * key[c2, r1];

                            matrix[r, c] =
                                ((detInv * cofactor % 26) + 26) % 26;
                        }
                    }
                }
            }

            string result = "";

            for (int i = 0; i < clean.Length; i += size)
            {
                for (int r = 0; r < size; r++)
                {
                    int sum = 0;

                    for (int c = 0; c < size; c++)
                    {
                        sum += matrix[r, c] * (clean[i + c] - 'A');
                    }

                    int value = ((sum % 26) + 26) % 26;

                    result += (char)('A' + value);
                }
            }

            Console.WriteLine($"Result: {result}\n");
        }
    }
}
