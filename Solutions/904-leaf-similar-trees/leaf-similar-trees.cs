public class Solution
{
    public bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> ans1 = [], ans2 = [];

        dfs(root1, ans1);
        dfs(root2, ans2);

        return ans1.SequenceEqual(ans2);
    }

    private static void dfs(TreeNode? node, List<int> ans)
    {
        if (node is null) return;

        if (node.left is null && node.right is null)
            ans.Add(node.val);

        else
        {
            dfs(node.left, ans);
            dfs(node.right, ans);
        }
    }
}