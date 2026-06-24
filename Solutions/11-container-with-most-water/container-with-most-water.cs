public class Solution
{
    public int MaxArea(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int maxArea = 0;

        while (left < right)
        {
            int h1 = height[left], h2 = height[right];
            int area = right - left;

            if (h1 < h2)
            {
                left++;
                area *= h1;
            }

            else
            {
                right--;
                area *= h2;
            }

            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }
}