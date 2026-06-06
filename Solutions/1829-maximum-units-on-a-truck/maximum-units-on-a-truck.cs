public class Solution
{
    private readonly static Comparer<int[]> comparer = 
        Comparer<int[]>.Create(
        (a, b) => b[1].CompareTo(a[1]));
    public int MaximumUnits(int[][] types, int maxBoxes)
    {
        int n = types.Length;
        types.Sort(comparer);
        int unitsLoaded = 0, spaceRemaining = maxBoxes;

        for (int i = 0; i < n; i++)
        {
            var type = types[i];
            (int boxes, int units) = (type[0], type[1]);

            if (spaceRemaining >= boxes)
            {
                spaceRemaining -= boxes;
                unitsLoaded += (boxes * units);
            }

            else return unitsLoaded + (spaceRemaining * units);
        }

        return unitsLoaded;
    }
}