public class Solution
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root is null) return [];

        Queue<TreeNode> queue = [];
        List<IList<int>> ans = [];
        queue.Enqueue(root);
        int currlvl = 0;
        
        while (queue.Count > 0)
        {
            int size = queue.Count;
            int[] lvlArr = new int[size];
            currlvl++;

            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                lvlArr[i] = node.val;

                if (node.left is not null)
                    queue.Enqueue(node.left);
                
                if (node.right is not null)
                    queue.Enqueue(node.right);
            }

            ans.Add(lvlArr);
        }

        return ans;
    }
}