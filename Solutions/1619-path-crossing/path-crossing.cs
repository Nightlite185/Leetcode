using System.Drawing;

public class Solution
{
    public bool IsPathCrossing(string path)
    {
        HashSet<Point> seen = [Point.Empty];
        
        Point currPos = new(0, 0);

        Point north = new(0, 1),
              south = new(0, -1),
              east = new(1, 0),
              west = new(-1, 0);

        foreach(char dir in path)
        {
            currPos.Offset(dir switch 
            {
                'N' => north,
                'S' => south,
                'E' => east,
                'W' => west,

                _ => throw new ArgumentException(path)
            });

            if (!seen.Add(currPos))
                return true;
        }

        return false;
    }
}