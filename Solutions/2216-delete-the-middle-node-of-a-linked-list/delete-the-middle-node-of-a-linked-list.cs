public class Solution
{
    public ListNode? DeleteMiddle(ListNode? head)
    {
        if (head?.next is null) return null;

        ListNode? slow = head, fast = head, prevSlow = null;

        while (fast?.next is not null)
        {
            fast = fast.next?.next;

            prevSlow = slow;
            slow = slow!.next;
        }

        prevSlow!.next = slow!.next;
        return head;
    }
}