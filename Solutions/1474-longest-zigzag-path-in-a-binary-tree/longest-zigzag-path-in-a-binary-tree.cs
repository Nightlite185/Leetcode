public class Solution
{
    const bool Left = false, Right = true;

    public int LongestZigZag(TreeNode root)
    {
        int longest = 0;
        
        void Dfs(TreeNode? node, bool dir, int count)
        {
            if (node is null)
            {
                longest = Math.Max(longest, count);
                return;
            }

            if (dir == Left)
            {
                Dfs(node.right, Right, count + 1);
                Dfs(node.left, Left, 0);
            }
            
            else
            {
                Dfs(node.left, Left, count + 1);
                Dfs(node.right, Right, 0);
            }
        }
        
        Dfs(root.left, Left, 0);
        Dfs(root.right, Right, 0);

        return longest;
    }
}