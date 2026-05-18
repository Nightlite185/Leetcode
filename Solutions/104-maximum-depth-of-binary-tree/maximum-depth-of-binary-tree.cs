public class Solution
{
    public int MaxDepth(TreeNode root)
    {
        int maxDepth = 0;
        int dummy = 0;

        void dfs(TreeNode? node, ref int depth)
        {
            if (node is null) return;

            depth++;
            
            dfs(node.left,  ref depth);
            dfs(node.right, ref depth);

            maxDepth = Math.Max(maxDepth, depth);
            depth--;
        }

        dfs(root, ref dummy);
        return maxDepth;
    }
}