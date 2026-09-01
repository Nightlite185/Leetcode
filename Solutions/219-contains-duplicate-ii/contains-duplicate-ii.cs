using static System.Runtime.InteropServices.CollectionsMarshal;

public class Solution
{
    public bool ContainsNearbyDuplicate(int[] nums, int maxDist)
    {
        var lastNums = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            ref int lastIdx = ref GetValueRefOrAddDefault(lastNums, num, out bool exist);

            if (exist && i - lastIdx <= maxDist)
                return true;

            lastIdx = i;
        }

        return false;
    }
}