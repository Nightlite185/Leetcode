public class Solution
{
    public bool IsValidBST(TreeNode root)
    {
        static bool dfs(TreeNode? node, long low, long high)
        {
            if (node is null)
                return true;

            if (node.val <= low || node.val >= high)
                return false;

            return dfs(node.left, low, high: node.val)
                && dfs(node.right, low: node.val, high);
        }

        return dfs(root,
            low: long.MinValue,
            high: long.MaxValue);
    }
}