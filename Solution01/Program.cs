namespace Solution01
{
    internal class Program
    {
        public static int[] RunningSum(int[] nums)
        {
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    nums[i] += nums[j];
                }
            }
            return nums;
        }
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4 };

            int[] result = RunningSum(nums);

            Console.WriteLine(string.Join(", ", result));
        }
    }
}
