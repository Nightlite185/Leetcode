public class Solution
{
    public IList<IList<int>> FindWinners(int[][] matches)
    {
        Dictionary<int, int> lossesByPlayer = [];
        HashSet<int> players = [];
        List<int>[] ans = [[], []];

        foreach (int[] match in matches)
        {
            int loser = match[1];

            // adding 1 for loses (match's idx 1)
            lossesByPlayer[match[1]] = lossesByPlayer.GetValueOrDefault(match[1]) + 1;

            // adding winner and loser to hashset to easily enumerate later
            players.UnionWith(match);
        }

        foreach (int player in players)
        {
            if (!lossesByPlayer.TryGetValue(player, out int loseCount)) 
                ans[0].Add(player);

            else if (loseCount == 1)
                ans[1].Add(player);
        }

        ans[0].Sort();
        ans[1].Sort();

        return ans;
    }
}