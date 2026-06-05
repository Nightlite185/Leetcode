public class Solution
{
    public int PartitionArray(int[] nums, int k)
    {
        nums.Sort();
        int groups = 1, lowest = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            int num = nums[i];

            if (num - lowest > k)
            {
                lowest = num;
                groups++;
            }
        }

        return groups;
    }
}