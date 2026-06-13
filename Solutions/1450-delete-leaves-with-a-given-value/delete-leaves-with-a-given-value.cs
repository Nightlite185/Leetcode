public class Solution
{
    public TreeNode? RemoveLeafNodes(TreeNode? root, int target)
    {
        if (root is null || dfs(root)) return null;
        
        return root;

        // returns whether this node is up for removal
        bool dfs(TreeNode? node)
        {
            if (node is null) return false;

            if (dfs(node.left)) node.left = null;
            if (dfs(node.right)) node.right = null;

            if (node.left is null && node.right is null && node.val == target)
                return true;

            return false;
        }
    }
}