using static System.Math;
public class Solution
{
    public int DiameterOfBinaryTree(TreeNode? root)
    {
        int maxDiam = int.MinValue;

        int dfs(TreeNode? node)
        {
            if (node is null) return 0;

            int left = dfs(node.left);
            int right = dfs(node.right);

            maxDiam = Max(maxDiam, left + right);

            return Max(left, right) + 1;
        }

        _ = dfs(root);
        return maxDiam;
    }
}