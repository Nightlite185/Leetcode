public class Solution
{
    const int modulo = 1_000_000_007;
    public int NumRollsToTarget(int dices, int faces, int target)
    {
        var memo = new int?[target, dices+1];
        
        int dp(int sum, int remRolls)
        {
            if (remRolls < 0) return 0;

            else if (sum == target)
            {
                return (remRolls == 0)
                    ? 1 : 0;
            }

            else if (memo[sum, remRolls] is int m)
                return m;

            long waysFromHere = 0;

            for (int f = 1; f <= faces; f++)
            {
                int newSum = sum + f;
                if (newSum > target) break;

                waysFromHere += dp(newSum, remRolls - 1);
            }

            int res = (int)(waysFromHere % modulo);
            memo[sum, remRolls] = res;
            return res;
        }

        return dp(0, dices);
    }
}