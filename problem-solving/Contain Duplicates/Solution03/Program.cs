namespace Solution03
{
    internal class Program
    {
        public static bool ContainsDuplicate(int[] nums)
        {

            bool flag=false;
            HashSet<int> seen = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!seen.Add(nums[i])) { 
                    flag= true;
                    break;
                }


        }

            return flag ? true : false;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter numbers separated by spaces: ");

            int[] nums = Console.ReadLine()!
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool result = ContainsDuplicate(nums);

            Console.WriteLine($"Contains Duplicate: {result}");
        }
    }
}
