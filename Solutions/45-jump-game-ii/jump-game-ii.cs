public class Solution
{
    public int Jump(int[] nums)
    {
        int r = 0, l = 0;
        int level = 0;

        while (r < nums.Length - 1)
        {
            int farthest = 0;

            for (int i = l; i <= r; i++)
            {
                farthest = Math.Max(farthest, i + nums[i]);
            }

            l = r+1;
            r = farthest;

            level++;
        }

        return level;
    }
}