public class Solution
{
    public int MinimumCardPickup(int[] cards)
    {
        Dictionary<int, int> lastSeenIdxs = [];
        int result = int.MaxValue;

        for (int i = 0; i < cards.Length; i++)
        {
            int card = cards[i];

            if (lastSeenIdxs.TryGetValue(card, out int foundIdx))
                result = Math.Min(result,  i - foundIdx + 1);

            lastSeenIdxs[card] = i;
        }

        return (result == int.MaxValue) 
            ? -1 
            : result;
    }
}