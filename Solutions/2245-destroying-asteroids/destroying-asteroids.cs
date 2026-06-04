public class Solution
{
    public bool AsteroidsDestroyed(int mass, int[] asteroids)
    {
        asteroids.Sort();
        long planet = mass;

        foreach(int a in asteroids)
        {
            if (a > planet) return false;
            planet += a;
        }

        return true;
    }
}