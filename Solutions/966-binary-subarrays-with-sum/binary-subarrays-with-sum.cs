public class Solution
{
    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        int currSum = 0, ans = 0, left = 0, prefixZeroes = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            currSum += nums[right];

            while (left < right && (nums[left] == 0 || currSum > goal))
            {
                if (nums[left] == 0)
                    prefixZeroes++;

                else prefixZeroes = 0;

                currSum -= nums[left++];
            }

            if (currSum == goal)
                ans += prefixZeroes + 1;
        }

        return ans;
    }
}