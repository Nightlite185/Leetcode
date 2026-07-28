public class Solution
{
    public int Rob(TreeNode root)
    {
        var memo = new Dictionary<TreeNode, int>();

        int dp(TreeNode? node)
        {
            if (node is null) return 0;

            if (memo.TryGetValue(node, out int val))
                return val;
            
            var next1 = node.left;
            var next2 = node.right;
            
            int skip = dp(next1) + dp(next2);

            int take = node.val 
                + dp(next1?.left)
                + dp(next1?.right)
                + dp(next2?.left)
                + dp(next2?.right);

            int res = Math.Max(take, skip);
            
            memo[node] = res;
            return res;
        }

        return dp(root);
    }
}