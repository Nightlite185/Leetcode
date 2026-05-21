using static System.Math;
public class Solution
{
    public int ClosestValue(TreeNode root, double target)
    {
        int closest = int.MaxValue;
        double minDiff = double.PositiveInfinity;

        void dfs(TreeNode? node)
        {
            if (node is null) return;

            double diff = Abs(node.val - target);

            if (diff < minDiff)
            {
                minDiff = diff;
                closest = node.val;
            }

            else if (diff == minDiff)
                closest = Min(closest, node.val);


            if (target > node.val)
                dfs(node.right);

            else if (target < node.val)
                dfs(node.left);

            else return;
        }

        dfs(root);
        return closest;
    }
}