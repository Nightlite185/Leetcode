public class Solution
{
    public double MyPow(double x, long n) 
    {
        return (n == 0)     ? 1
             : (x == 1)     ? x
             : (n < 0)      ? MyPow(1 / x, -n)
             : (n % 2 == 0) ? MyPow(x*x, n/2)
             : x * MyPow(x*x, n/2);
    }
}