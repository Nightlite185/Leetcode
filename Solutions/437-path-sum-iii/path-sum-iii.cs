using static System.Runtime.InteropServices.CollectionsMarshal;

public class Solution
{
    public int PathSum(TreeNode root, int targetSum)
    {
        Dictionary<long, int> prefixSums = [];
        int validPaths = 0;

        void dfs(TreeNode? node, long currSum)
        {
            if (node is null) return;

            currSum += node.val;

            if (currSum == targetSum)
                validPaths++;

            if (prefixSums.TryGetValue(currSum - targetSum, out int count))
                validPaths += count;

            if (node.left is null && node.right is null)    
                return;

            GetValueRefOrAddDefault(prefixSums, currSum, out _)++;

            dfs(node.left, currSum);
            dfs(node.right, currSum);

            GetValueRefOrNullRef(prefixSums, currSum)--;
        }

        dfs(root, 0);
        return validPaths;
    }
}