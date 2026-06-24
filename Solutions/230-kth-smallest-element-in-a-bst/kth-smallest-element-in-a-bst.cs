public class Solution
{
    public int KthSmallest(TreeNode root, int k)
    {
        int count = 0;
        int kth = 0;
        dfs(root);
        return kth;

        bool dfs(TreeNode? node)
        {
            if (node is null) return false;

            if (dfs(node.left)) return true;

            if (++count == k)
            {
                kth = node.val;
                return true;
            }

            if (dfs(node.right)) return true;

            return false;
        }
    }
}