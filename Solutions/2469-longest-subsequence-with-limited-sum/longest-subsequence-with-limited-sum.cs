public class Solution
{
    public int[] AnswerQueries(int[] nums, int[] queries)
    {
        var ans = new int[queries.Length];
        var prefixSum = new int[nums.Length];
        int currSum = 0;
        nums.Sort();

        for (int i = 0; i < nums.Length; i++)
        {
            currSum += nums[i];
            prefixSum[i] = currSum;
        }

        for (int i = 0; i < queries.Length; i++)
        {
            int target = queries[i];

            int bs()
            {
                int left = 0, right = nums.Length - 1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    int sum = prefixSum[mid];
                    
                    if (sum == target)
                        return mid + 1;

                    else if (sum > target)
                        right = mid - 1;

                    else left = mid + 1;
                }

                return left;
            }
        
            ans[i] = bs();
        }

        return ans;
    }
}