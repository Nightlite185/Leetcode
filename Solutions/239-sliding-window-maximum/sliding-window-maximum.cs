public class Solution
{
    public int[] MaxSlidingWindow(int[] nums, int size)
    {
        LinkedList<int> decr = [];
        int[] ans = new int[nums.Length - size + 1];
        
        for (int i = 0; i < nums.Length; i++)
        {
            int curr = nums[i];

            while (decr.Count > 0 && curr > nums[decr.Last!.Value])
                decr.RemoveLast();

            decr.AddLast(i);

            // if highest el is outside the window -> pop it
            if (decr.First?.Value + size == i)
                decr.RemoveFirst();

            if (i >= size - 1)
                ans[i - size + 1] = nums[decr.First!.Value];
        }

        return ans;
    }
}