public class Solution
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (left == right) return head;

        ListNode? prev = null;
        ListNode? curr = head;

        ListNode firstRev = null!,
        lastRev = null!,
        tailStart = null!,
        headEnd = null!;

        for (int i = 1; curr is not null; i++)
        {
            if (i <= left || i > right) // outside of reverse (already / not yet)
            {
                if (i == left)
                {
                    firstRev = curr;
                    headEnd = prev!;
                }

                prev = curr;
                curr = curr.next;
            }

            else // reverse part
            {
                if (i == right)
                {
                    lastRev = curr;
                    tailStart = curr.next!;
                }

                var next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }
        }

        if (headEnd is not null)
            headEnd.next = lastRev;

        else head = lastRev;

        firstRev!.next = tailStart;

        return head;
    }
}