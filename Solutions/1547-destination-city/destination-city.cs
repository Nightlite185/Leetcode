public class Solution
{
    public string DestCity(IList<IList<string>> paths)
    {
        HashSet<string> notDest = [], potentialDest = [];

        foreach(var edge in paths)
        {
            notDest.Add(edge[0]);
            potentialDest.Add(edge[1]);
        }

        potentialDest.ExceptWith(notDest);
        return potentialDest.Single();
    }
}