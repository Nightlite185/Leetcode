using System.Security.AccessControl;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        nums.Sort();
        var res = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            int right = nums.Length-1, left = i + 1;
            int a = nums[i];

            if (i > 0 && a == nums[i-1])
                continue;

            while (left < right)
            {
                int sum = a + nums[left] + nums[right];

                if (sum > 0)
                    right--;

                else if (sum < 0)
                    left++;

                else
                {
                    res.Add([a, nums[left], nums[right]]);
                    
                    do left++;

                    while (left < right
                    && nums[left] == nums[left - 1]);
                }
            }
        }

        return res;
    }
}