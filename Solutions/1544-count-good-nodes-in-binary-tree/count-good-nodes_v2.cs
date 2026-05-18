public class Solution
{
    public int GoodNodes(TreeNode root)
    {
        static int isGood(TreeNode? node, int maxVal)
        {
            if (node is null) return 0;

            int ans = (node.val >= maxVal) 
                ? 1 : 0;

            maxVal = Math.Max(maxVal, node.val);

            return isGood(node.left, maxVal) 
                 + isGood(node.right, maxVal)
                 + ans;
        }

        return isGood(root, int.MinValue);
    }
}