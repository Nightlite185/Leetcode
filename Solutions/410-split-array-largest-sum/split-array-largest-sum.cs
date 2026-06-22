public class Solution
{
    public int SplitArray(int[] nums, int maxParts)
    {
        int left = 0, right = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            right += num;
            left = Math.Max(left, num);
        }

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (check(mid)) right = mid;

            else left = mid + 1;
        }

        return left;

        bool check(int mid)
        {
            int currParts = 1;
            int currSum = 0;

            foreach(int num in nums)
            {
                currSum += num;
                
                if (currSum > mid)
                {
                    currSum = num;
                    currParts++;
                }
            }

            return currParts <= maxParts;
        }
    }
}