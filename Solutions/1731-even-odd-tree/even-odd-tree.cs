public class Solution
{
    public bool IsEvenOddTree(TreeNode root)
    {
        int currLvl = -1;
        Queue<TreeNode> queue = [];
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int lvlSize = queue.Count;
            int? prevVal = null;
            currLvl++;

            for (int i = 0; i < lvlSize; i++)
            {
                var node = queue.Dequeue();

                if (node.left is not null)
                    queue.Enqueue(node.left);
                
                if (node.right is not null)
                    queue.Enqueue(node.right);
                
                // =========================== //

                // even lvl: ASC order, ONLY ODD VALUES
                if (currLvl % 2 == 0)
                {
                    if (node.val <= prevVal || node.val % 2 == 0)
                        return false;
                }

                // odd lvl: DESC order, ONLY EVEN VALUES
                else if (node.val >= prevVal || node.val % 2 != 0)
                    return false;

                prevVal = node.val;
            }
        }

        return true;
    }
}