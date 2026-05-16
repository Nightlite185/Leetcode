public class Solution
{
    public int[] DailyTemperatures(int[] temps)
    {
        Stack<int> stack = [];
        int[] ans = new int[temps.Length];

        for (int i = 0; i < temps.Length; i++)
        {
            int curr = temps[i];

            while (stack.TryPeek(out int topIdx) 
                && curr > temps[topIdx])
            {
                int j = stack.Pop();
                ans[j] = i - j;
            }

            stack.Push(i);
        }

        return ans;
    }
}