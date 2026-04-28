public class Solution
{
    public bool HasCycle(ListNode? head)
    {
        while (head is not null)
        {
            if (head.val == int.MaxValue)
                return true;

            head.val = int.MaxValue;
            head = head.next;
        }

        return false;
    }
}
