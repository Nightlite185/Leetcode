public class Solution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        int n = nums.Length, currSum = 0, left = 0, maxSum = 0;
        HashSet<int> window = [];

        for (int right = 0; right < n; right++)
        {
            int rightNum = nums[right];
            currSum += rightNum;

            while (!window.Add(rightNum))
            {
                int leftNum = nums[left++];

                currSum -= leftNum;
                window.Remove(leftNum);
            }

            maxSum = Math.Max(maxSum, currSum);
        }

        return maxSum;
    }
}