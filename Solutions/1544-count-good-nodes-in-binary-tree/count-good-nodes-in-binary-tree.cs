public class Solution
{
    public int GoodNodes(TreeNode root)
    {
        int goodCount = 0;

        void isGood(TreeNode? node, int maxVal)
        {
            if (node is null) return;

            if (node.val >= maxVal) 
                goodCount++;

            maxVal = Math.Max(maxVal, node.val);

            isGood(node.left, maxVal);
            isGood(node.right, maxVal);
        }

        isGood(root, int.MinValue);
        return goodCount;
    }
}