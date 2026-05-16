public class Solution
{
    public int[] NextGreaterElement(int[] nums1, int[] nums2)
    {
        int[] ans = new int[nums1.Length];
        Array.Fill(ans, -1);
        
        Stack<int> stack = [];

        var subset = new Dictionary<int, int>(nums1.Length);

        for (int i = 0; i < nums1.Length; i++)
            subset[nums1[i]] = i;

        for (int i = 0; i < nums2.Length; i++)
        {
            int curr = nums2[i];

            while (stack.TryPeek(out int top) && curr > top)
            {
                int popped = stack.Pop();
                
                if (subset.TryGetValue(popped, out int idx))
                    ans[idx] = curr;
            }

            stack.Push(curr);
        }

        return ans;
    }
}