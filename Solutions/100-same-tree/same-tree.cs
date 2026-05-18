public class Solution
{
    public bool IsSameTree(TreeNode? t1, TreeNode? t2)
    {
        if (t1 is null && t2 is null) 
            return true;

        if (t1?.val != t2?.val)
            return false;

        return IsSameTree(t1?.left, t2?.left)
            && IsSameTree(t1?.right, t2?.right);
    }
}