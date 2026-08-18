namespace Solution06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { -2, 0, 3, -5, 2, -1 };

            NumArray obj = new NumArray(nums);

            Console.WriteLine(obj.SumRange(0, 2));
            Console.WriteLine(obj.SumRange(2, 5));
            Console.WriteLine(obj.SumRange(0, 5));
        }
    }
}
