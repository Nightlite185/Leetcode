public class Solution
{
    public string DestCity(IList<IList<string>> paths)
    {
        HashSet<string> notDest = [];
        HashSet<string> allCities = [];

        foreach(var edge in paths)
        {
            (string? a, string? b) = (edge[0], edge[1]);
            allCities.Add(a); allCities.Add(b);

            notDest.Add(a);
        }

        allCities.ExceptWith(notDest);

        return allCities.Single();
    }
}