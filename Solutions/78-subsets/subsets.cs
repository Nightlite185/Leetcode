public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        Stack<int> curr = [];
        List<IList<int>> ans = [];

        void bt(int startIdx)
        {
            if (startIdx > nums.Length)
                return;
            
            ans.Add([..curr]);

            for (int i = startIdx; i < nums.Length; i++)
            {
                curr.Push(nums[i]);
                bt(i + 1);
                curr.Pop();
            }
        }

        bt(0);
        return ans;
    }
}