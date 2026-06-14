public class Solution
{
    public TreeNode? LowestCommonAncestor(TreeNode? root, TreeNode p, TreeNode q)
    {
        int pv = p.val, qv = q.val;

        TreeNode? dfs(TreeNode? node)
        {
            if (node is null) return null;

            int curr = node.val;

            if (pv > curr && qv > curr)
                return dfs(node.right);

            else if (pv < curr && qv < curr)
                return dfs(node.left);

            else return node;
        }

        return dfs(root);
    }
}