public class Solution
{
    public bool HasCycle(ListNode? head)
    {
        var fast = head;
        var slow = head;

        while (true)
        {
            slow = slow?.next;
            fast = fast?.next?.next;

            if (fast is null || slow is null)
                return false;

            if (fast == slow)
                return true;
        }
    }
}