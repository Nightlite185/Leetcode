public class Solution
{
    public TreeNode? DeleteNode(TreeNode? root, int target)
    {
        if (root is null) return null;

        TreeNode? found = null, prev = null;
        TreeNode dummy = new(int.MinValue, null, root);
        
        void RemoveHelper(TreeNode? replaceWith)
        {
            if (prev?.left == found)
                prev.left = replaceWith;

            else prev!.right = replaceWith;
        }

        bool dfs(TreeNode? node)
        {
            if (node is null) return false;
            if (node.val == target)
            {
                found = node;
                return true;
            }

            else if (target > node.val)
            {
                if (dfs(node.right))
                {
                    prev = node;
                    return false;
                }
            }

            else if (dfs(node.left))
                prev = node;

            return false;
        }
        void dfsAppendRight(TreeNode node, TreeNode? append)
        {
            if (node.right is null)
                node.right = append;

            else dfsAppendRight(node.right, append);
        }

        dfs(dummy);

        if (found is null) return dummy.right;
        if (prev is null) return null;

        // both children null
        if (found.right is null && found.left is null)
        {
            RemoveHelper(null);
            return dummy.right;
        }

        // both children exist
        else if (found.left is not null && found.right is not null)
        {
            if (prev?.left == found)
            {
                prev.left = found.left;

                // go dfs from found.left and append found.right to the deepest rightmost leaf's right.
                dfsAppendRight(node: found.left, append: found.right);
            }

            else // found is on the prev.right
            {
                prev!.right = found.left;

                // go dfs from found.left and append found.right to the deepest rightmost leaf's right.
                dfsAppendRight(node: found.left, append: found.right);
            }
        }

        // only right child exists
        else if (found.right is not null)
            RemoveHelper(found.right);

        // only left child exists
        else if (found.left is not null)
            RemoveHelper(found.left);

        return dummy.right;
    }
}