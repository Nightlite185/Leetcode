public class Solution
{
    public int RangeSumBST(TreeNode root, int low, int high)
    {
        int ans = 0;

        void dfs(TreeNode? node)
        {
            if (node is null) return;

            // in range
            if (node.val >= low && node.val <= high)
                ans += node.val;

            if (node.val > low)
                dfs(node.left);

            if (node.val < high)
                dfs(node.right);
        }

        dfs(root);
        return ans;
    }
}