public class Solution
{
    public TreeNode InsertIntoBST(TreeNode? root, int val)
    {
        var newNode = new TreeNode(val);

        if (root is null) return newNode;

        void dfs(TreeNode node)
        {
            if (val > node.val)
            {
                if (node.right is null)
                {
                    node.right = newNode;
                    return;
                }

                dfs(node.right);
            }

            else if (node.left is null)
            {
                node.left = newNode;
                return;
            }

            else dfs(node.left);
        }

        dfs(root);

        return root;
    }
}