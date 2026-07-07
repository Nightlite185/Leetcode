public class Solution
{
    public int Trap(int[] height)
    {
        if (height.Length == 0)
            return 0;

        int leftMax = height[0];
        int rightMax = height[^1];
        int water = 0;

        int lp = 0, rp = height.Length - 1;

        while (lp < rp)
        {
            if (leftMax <= rightMax)
            {
                lp++;

                leftMax = Math.Max(leftMax, height[lp]);
                water += leftMax - height[lp];
            }

            else
            {
                rp--;

                rightMax = Math.Max(rightMax, height[rp]);
                water += rightMax - height[rp];
            }
        }

        return water;
    }
}