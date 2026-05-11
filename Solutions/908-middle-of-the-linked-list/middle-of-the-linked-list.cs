public class Solution
{
    public ListNode? MiddleNode(ListNode head)
    {
        var fast = head;
        ListNode slow = head;

        while (fast is not null && fast?.next is not null)
        {
            fast = fast?.next?.next;
            slow = slow.next!;
        }

        return slow!;
    }
}