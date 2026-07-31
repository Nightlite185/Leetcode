public class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int n = nums.Length;
        int lastIdx = n-1;
        var memo = new Dictionary<long, int?[]>();

        int dp(int i, long sum)
        {
            if (i == lastIdx)
            {
                int res = 0;

                if (sum + nums[i] == target) res++;
                if (sum - nums[i] == target) res++;

                return res;
            }

            if (memo.TryGetValue(sum, out var memoArr) && memoArr[i] is int seen)
                return seen;

            int Ith = nums[i];

            int ans = dp(i + 1, sum - Ith)
                    + dp(i + 1, sum + Ith);

            if (memoArr is not null)
                memoArr[i] = ans;

            else
            {
                var newMemoArr = new int?[n];
                
                newMemoArr[i] = ans;
                memo[sum] = newMemoArr;
            }

            return ans;
        }

        return dp(0, 0);
    }
}