namespace Solution04
{
    internal class Program
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> seen = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int needed = target - nums[i];

                if (seen.ContainsKey(needed))
                {
                    return new int[] { seen[needed], i };
                }

                if (!seen.ContainsKey(nums[i]))
                {
                    seen.Add(nums[i], i);
                }
            }

            return new int[] { };
        }
        static void Main(string[] args)
        {
            Console.Write("Enter numbers separated by spaces: ");
            int[] nums = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.Write("Enter target: ");
            int target = int.Parse(Console.ReadLine()!);

            int[] result = TwoSum(nums, target);

            Console.WriteLine($"Result: [{string.Join(", ", result)}]");
        }
    }
}
