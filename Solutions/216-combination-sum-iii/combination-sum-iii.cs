public class Solution
{
    public IList<IList<int>> CombinationSum3(int length, int target)
    {
        List<IList<int>> ans = [];
        List<int> curr = [];

        bt(0, 0);
        
        void bt(int startIdx, int sum)
        {
            if (curr.Count == length)
            {
                if (sum == target)
                    ans.Add([..curr]);

                return;
            }

            for (int i = startIdx + 1; i < 10; i++)
            {
                if (sum + i > target) continue;

                curr.Add(i);
                bt(i, sum + i);
                curr.RemoveAt(curr.Count - 1);
            }
        }

        return ans;
    }
}