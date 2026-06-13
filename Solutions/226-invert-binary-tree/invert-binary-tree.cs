public class Solution
{
    public TreeNode? InvertTree(TreeNode? node)
    {
        if (node is null) return null;
        (node.right, node.left) = (node.left, node.right);

        InvertTree(node.left);
        InvertTree(node.right);

        return node;
    }
}