public class Solution
{
    public IList<IList<int>> PathSum(TreeNode? root, int targetSum)
    {
        if (root is null) return [];

        var paths = new List<IList<int>>();

        void dfs(TreeNode node, int sum, IList<int> tempPath)
        {
            sum += node.val;
            tempPath.Add(node.val);

            // if we are at leaf
            if (node.right is null && node.left is null)
            {
                if (sum == targetSum)
                    paths.Add([..tempPath]);

                tempPath.RemoveAt(tempPath.Count-1);
                return;
            }

            if (node.left is not null)
                dfs(node.left, sum, tempPath);

            if (node.right is not null)
                dfs(node.right, sum, tempPath);

            tempPath.RemoveAt(tempPath.Count-1);
        }

        dfs(root, 0, []);

        return paths;
    }
}