public class Solution
{
    public TreeNode? SearchBST(TreeNode root, int target)
    {
        TreeNode? found = null;

        void dfs(TreeNode? node)
        {
            if (node is null) return;
            
            if (node.val == target)
                found = node;

            else if (target > node.val)
                dfs(node.right);

            else dfs(node.left);
        }

        dfs(root);
        return found;
    }
}