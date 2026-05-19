public class Solution
{
    public int MinDepth(TreeNode? root)
    {
        if (root is null) return 0;

        int min = int.MaxValue;

        void dfs(TreeNode? node, int depth)
        {
            if (node is null) return;

            depth++;

            if (node.left is null && node.right is null)
            {
                min = Math.Min(min, depth);
                return;
            }

            dfs(node.left, depth);
            dfs(node.right, depth);
        }

        dfs(root, 0);
        return min;
    }
}