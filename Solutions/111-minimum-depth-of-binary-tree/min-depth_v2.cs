public class Solution
{
    public int MinDepth(TreeNode? node)
    {
        if (node is null) return 0;

        if (node.right is null)
            return MinDepth(node.left) + 1;

        if (node.left is null)
            return MinDepth(node.right) + 1;

        return Math.Min(
            MinDepth(node.left),
            MinDepth(node.right)) + 1;
    }
}