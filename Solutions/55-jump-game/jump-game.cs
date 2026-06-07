public class Solution
{
    public bool CanJump(int[] nums)
    {
        int rightBound = nums.Length - 1;
        var seen = new bool[nums.Length];

        bool dfs(int node)
        {
            int jumps = nums[node];
            int maxJump = node + jumps;

            if (maxJump >= rightBound)
                return true;

            for (int i = 1; i <= maxJump; i++)
            {
                if (seen[i]) continue;
                seen[i] = true;

                if (dfs(i)) return true;
            }

            return false;
        }

        return dfs(0);
    }
}