using static System.Math;

public class Solution
{
    public int GetMinimumDifference(TreeNode root)
    {
        int ans = int.MaxValue;
        int? prev = null;

        void dfs(TreeNode? node)
        {
            if (node is null) return;

            dfs(node.left);

            if (prev is int realPrev)
                ans = Min(ans, node.val - realPrev);

            prev = node.val;

            dfs(node.right);
        }

        dfs(root);
        return ans;
    }
}