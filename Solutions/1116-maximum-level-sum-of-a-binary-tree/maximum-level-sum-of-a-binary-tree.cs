public class Solution
{
    public int MaxLevelSum(TreeNode root)
    {
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);
        int lvl = 0;
        int maxSum = int.MinValue;
        int lvlWithMaxSum = 0;

        while (queue.Count > 0)
        {
            int sum = 0, size = queue.Count;
            lvl++;

            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;

                if (node.left is not null)
                    queue.Enqueue(node.left);
                
                if (node.right is not null)
                    queue.Enqueue(node.right);
            }

            if (sum > maxSum)
            {
                maxSum = sum;
                lvlWithMaxSum = lvl;
            }
        }

        return lvlWithMaxSum;
    }
}