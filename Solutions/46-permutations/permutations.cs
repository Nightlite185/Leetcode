public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        List<IList<int>> ans = [];
        
        void bt(List<int> curr, HashSet<int> currSet)
        {
            if (curr.Count == nums.Length)
            {
                ans.Add([..curr]);
                return;
            }

            foreach(int num in nums)
            {
                if (currSet.Contains(num))
                    continue;

                curr.Add(num);
                currSet.Add(num);

                bt(curr, currSet);

                curr.RemoveAt(curr.Count - 1);
                currSet.Remove(num);
            }
        }

        bt([], []);
        return ans;
    }
}