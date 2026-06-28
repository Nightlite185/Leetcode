public class Solution
{
    public IList<IList<int>> CombinationSum(int[] nums, int target)
    {
        List<IList<int>> ans = [];
        List<int> path = [];

        void bt(int start, int sum)
        {
            if (sum == target)
            {
                ans.Add([..path]);
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                int num = nums[i];

                if (sum + num > target)
                    continue;

                path.Add(num);
                bt(i, sum + num);
                path.RemoveAt(path.Count-1);
            }
        }

        bt(0, 0);
        return ans;
    }
}