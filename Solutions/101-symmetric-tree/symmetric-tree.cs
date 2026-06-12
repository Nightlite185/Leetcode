public class Solution
{
    public bool IsSymmetric(TreeNode root)
        => Dfs(root.left, root.right);

    private static bool Dfs(TreeNode? left, TreeNode? right)
    {
        if (left is null && right is null)
            return true;

        if (left?.val != right?.val)
            return false;

        return Dfs(left.left, right.right) 
            && Dfs(left.right, right.left);
    }
}