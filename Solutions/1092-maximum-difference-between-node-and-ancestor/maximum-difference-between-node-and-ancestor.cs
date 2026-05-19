using static System.Math;
public class Solution
{
    public int MaxAncestorDiff(TreeNode root)
    {
        int dfs(TreeNode? node, int min, int max)
        {
            if (node is null) return 0;

            min = Min(min, node.val);
            max = Max(max, node.val);

            int left = dfs(node.left, min, max);
            int right = dfs(node.right, min, max);

            int diff = Abs(max - min);

            return Max(Max(diff, left), right);
        }

        return dfs(root, int.MaxValue, int.MinValue);
    }
}