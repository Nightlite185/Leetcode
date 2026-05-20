public class Solution
{
    public int DeepestLeavesSum(TreeNode root)
    {
        if (root is null) return 0;

        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        int sum = 0;

        while (queue.Count > 0)
        {
            int lvlCount = queue.Count;
            sum = 0;

            for (int i = 0; i < lvlCount; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;

                if (node.right is not null)
                    queue.Enqueue(node.right);
                
                if (node.left is not null)
                    queue.Enqueue(node.left);
            }
        }

        return sum;
    }
}