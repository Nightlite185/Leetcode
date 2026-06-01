public class Solution
{
    public bool CanReach(int[] jumps, int start)
    {
        var seen = new bool[jumps.Length];
        int upperBound = jumps.Length - 1;

        bool dfs(int idx)
        {
            if (idx < 0 || idx > upperBound || seen[idx])
                return false;

            seen[idx] = true;
            int jumpCount = jumps[idx];

            if (jumpCount == 0) return true;

            return dfs(idx + jumpCount)
                || dfs(idx - jumpCount);
        }

        return dfs(start);
    }
}