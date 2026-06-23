public class Solution : GuessGame
{
    const int Success = 0, TooLow = +1;
    public int GuessNumber(int n)
    {
        int left = 1, right = n;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int result = guess(mid);

            if (result == Success)
                return mid;

            else if (result == TooLow)
                left = mid + 1;
            
            else right = mid - 1;
        }

        return -1;
    }
}