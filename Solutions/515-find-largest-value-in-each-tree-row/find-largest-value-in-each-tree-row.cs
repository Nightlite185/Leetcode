public class Solution
{
    public IList<int> LargestValues(TreeNode? root)
    {
        if (root is null) 
            return Array.Empty<int>();

        Queue<TreeNode> queue = [];
        List<int> ans = [];

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int floorWidth = queue.Count;
            int max = int.MinValue;

            for (int i = 1; i <= floorWidth; i++)
            {
                var node = queue.Dequeue();

                if (node.left is not null)
                    queue.Enqueue(node.left);

                if (node.right is not null)
                    queue.Enqueue(node.right);

                // ===== ACTUAL WORK BELOW ===== //
                max = Math.Max(max, node.val);
            }

            ans.Add(max);
        }

        return ans;
    }
}