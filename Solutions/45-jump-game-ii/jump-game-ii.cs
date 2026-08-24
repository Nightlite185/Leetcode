public class Solution
{
    public int Jump(int[] nums)
    {
        int n = nums.Length;
        int maxIdx = n-1;
        var memo = new int?[n];

        int dp(int i)
        {
            if (i == maxIdx) return 0;
            if (memo[i] is int m) return m;

            int bound = Math.Min(
                maxIdx, i + nums[i]);

            int min = int.MaxValue;

            for (int j = i+1; j <= bound; j++)
            {
                int next = dp(j);

                if (next == int.MaxValue) continue;

                min = Math.Min(min, 1 + next);
            }

            memo[i] = min;
            return min;
        }

        return dp(0);
    }
}