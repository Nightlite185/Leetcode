public class NumArray
{
    private int[] sums, nums;
    public NumArray(int[] nums)
    {
        this.nums = nums;
        sums = new int[nums.Length];
        int curr = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            curr += nums[i];
            sums[i] = curr;
        }
    }

    public int SumRange(int left, int right)
    {
        if (left == right)
            return nums[left];

        return sums[right] - sums.ElementAtOrDefault(left-1);
    }
}