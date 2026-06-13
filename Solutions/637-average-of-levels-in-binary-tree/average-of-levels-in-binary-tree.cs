public class Solution
{
    public IList<double> AverageOfLevels(TreeNode root)
    {
        int currLvl = -1;
        List<double> ans = [];
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            double sum = 0;
            currLvl++;
            
            for (int i = 0; i < lvlSize; i++)
            {
                var node = queue.Dequeue();
                sum += node.val;

                if (node.left is not null)
                    queue.Enqueue(node.left);
                
                if (node.right is not null)
                    queue.Enqueue(node.right);
            }
        
            ans.Add(sum / lvlSize);
        }

        return ans;
    }
}