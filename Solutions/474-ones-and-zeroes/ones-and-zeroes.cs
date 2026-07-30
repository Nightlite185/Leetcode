public class Solution
{
    public int FindMaxForm(string[] strs, int zeroLimit, int oneLimit)
    {
        int n = strs.Length;
        var memo = new int?[n, zeroLimit+1, oneLimit+1];
        
        var counted = strs.Select(s => (
            zeroes: s.Count(c => c == '0'),
            ones: s.Count(c => c == '1')
        )).ToArray();

        int dp(int i, int zeroCount, int oneCount)
        {
            if (zeroCount > zeroLimit || oneCount > oneLimit)
                return int.MinValue;

            if (i >= n) return 0;

            if (memo[i, zeroCount, oneCount] is int m)
                return m;

            var (zeroes, ones) = counted[i];

            int ans = Math.Max(
                1 + dp(i+1, zeroCount + zeroes, oneCount + ones),
                dp(i+1, zeroCount, oneCount));

            memo[i, zeroCount, oneCount] = ans;
            return ans;
        }

        return dp(0, 0, 0);
    }
}