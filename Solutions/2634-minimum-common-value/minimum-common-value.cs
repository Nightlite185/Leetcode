public class Solution
{
    public int GetCommon(int[] nums1, int[] nums2)
    {
        int p1 = 0, p2 = 0, 
            length1 = nums1.Length, 
            length2 = nums2.Length;

        while (p1 < length1 && p2 < length2)
        {
            int num1 = nums1[p1];
            int num2 = nums2[p2];

            if (num1 == num2)
                return nums1[p1];

            if (num1 > num2) p2++;
            else p1++;
        }

        return -1;
    }
}