public class Solution
{
    public bool HasPathSum(TreeNode root, int targetSum)
    {
        bool dfs(TreeNode? node, int count)
        {
            if (node is null) return false;

            count += node.val;

            if (node.left is null && node.right is null)
                return count == targetSum;

            return dfs(node.left, count) 
                || dfs(node.right, count);
        }

        return dfs(root, 0);
    }
}