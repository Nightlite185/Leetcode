public class Solution
{
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
        if (root is null) return [];

        List<IList<int>> ans = [];
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        bool stdOrder = true;

        while (queue.Count > 0)
        {
            int lvlWidth = queue.Count;
            int[] level = new int[lvlWidth];

            for (int i = 0; i < lvlWidth; i++)
            {
                var node = queue.Dequeue();

                level[stdOrder ? i : (lvlWidth - i - 1)]
                    = node.val;

                if (node.left is not null)
                    queue.Enqueue(node.left);
                
                if (node.right is not null)
                    queue.Enqueue(node.right);
            }

            ans.Add(level);
            stdOrder = !stdOrder;
        }

        return ans;
    }
}