using System;
using System.Collections.Generic;
using System.Text;

namespace Solution06
{
    public class NumArray
    {

        private int[] nums;
        public NumArray(int[] nums)
        {
            this.nums = nums;
        }


        public int SumRange(int left, int right)
        {
            int Sum = 0;
            for (int i = left; i <= right; i++)
            {
                Sum += nums[i];

            }

            return Sum;
        }
    }

}
