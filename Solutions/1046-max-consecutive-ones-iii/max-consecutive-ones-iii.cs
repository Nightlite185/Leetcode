public class Solution
{
    public int LongestOnes(int[] nums, int k)
    {
        int zeroes = 0, left = 0, longest = 0;
        
        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
                zeroes++;

            while(zeroes > k)
            {
                if (nums[left] == 0)
                    zeroes--;

                left++;
            }

            longest = Math.Max(longest, right - left + 1);
        }

        return longest;
    }
}