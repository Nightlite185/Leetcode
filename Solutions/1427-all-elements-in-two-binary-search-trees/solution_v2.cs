public class Solution
{
    public IList<int> GetAllElements(TreeNode root1, TreeNode root2)
    {
        Queue<int> q1 = [], q2 = [];
        
        GetInOrder(root1, q1);
        GetInOrder(root2, q2);

        int n = q1.Count + q2.Count;
        int[] ans = new int[n];
        int i = 0;

        while (q1.Count > 0 && q2.Count > 0)
        {
            if (q1.Peek() <= q2.Peek())
                ans[i++] = q1.Dequeue();

            else ans[i++] = q2.Dequeue();
        }

        while (q1.Count > 0)
            ans[i++] = q1.Dequeue();

        while (q2.Count > 0)
            ans[i++] = q2.Dequeue();
        
        return ans;
    }

    private static void GetInOrder(TreeNode? node, Queue<int> q)
    {
        if (node is null) return;

        GetInOrder(node.left, q);

        q.Enqueue(node.val);

        GetInOrder(node.right, q);
    }
}