namespace Solution02
{
    internal class Program
    {
        public static int[] PlusOne(int[] digits)
        {
            int i = digits.Length - 1;
            int reminder;
            int number;
            while (i >= 0)
            {
                number = digits[i] += 1;
                if (number >= 10)
                {
                    reminder = number % 10;
                    digits[i] = reminder;
                    number = number / 10;
                    if (i == 0)
                    {
                        int[] result = new int[digits.Length + 1];
                        result[0] = number;

                        for (int j = 0; j < digits.Length; j++)
                        {
                            result[j + 1] = digits[j];
                        }

                        return result;
                    }
                }
                else
                {
                    digits[i] = number;
                    break;
                }


                i--;
            }

            return digits;
        }
        static void Main(string[] args)
        {
            int[][] testCases =
         {
            new int[] { 1, 2, 3 },
            new int[] { 4, 3, 2, 1 },
            new int[] { 9 },
            new int[] { 1, 9 },
            new int[] { 1, 2, 9 },
            new int[] { 1, 9, 9 },
            new int[] { 9, 9 },
            new int[] { 9, 9, 9 },
            new int[] { 8, 9, 9 },
            new int[] { 1, 0, 0 },
            new int[] { 5, 6, 7 },
            new int[] { 1, 8, 9, 9 }
        };

            foreach (int[] testCase in testCases)
            {
                int[] input = (int[])testCase.Clone();

                int[] result = PlusOne(testCase);

                Console.WriteLine(
                    $"Input: [{string.Join(", ", input)}] " +
                    $"-> Output: [{string.Join(", ", result)}]"
                );
            }
        }
    }
}
