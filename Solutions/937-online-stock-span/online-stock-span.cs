public class StockSpanner
{
    private Stack<StockRecord> stack = [];

    public int Next(int price)
    {
        int ans = 1;

        while (stack.TryPeek(out var top) && price >= top.Price)
            ans += stack.Pop().SpanValue;

        stack.Push(new(price, ans));

        return ans;
    }

    private readonly record struct StockRecord(
        int Price, 
        int SpanValue);
}