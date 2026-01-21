public class Solution 
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int endIdx = nums1.Length - 1;

        if (n == 0) return;

        while(n > 0 && m > 0)
        {
            if (nums2[n-1] >= nums1[m-1])
            {
                nums1[endIdx] = nums2[n-1];
                n--;
            }

            else
            {
                nums1[endIdx] = nums1[m-1];
                m--;
            }

            endIdx--;
        }

        while (n > 0)
        {
            nums1[endIdx] = nums2[n-1];

            n--;
            endIdx--;
        }
    }
}
