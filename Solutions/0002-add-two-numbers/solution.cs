public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        int[] list1 = [..AsEnumerable(l1)];
        int[] list2 = [..AsEnumerable(l2)];

        int carry = 0;
        
        var dummy = new ListNode();
        var node = dummy;

        for (int i = 0; i < list1.Length || i < list2.Length || carry != 0; i++)
        {
            node.next = new();
            node = node.next;

            int sum = list1.ElementAtOrDefault(i)
                    + list2.ElementAtOrDefault(i)
                    + carry;
            
            node.val = sum % 10;
            carry = sum / 10;
        }

        return dummy.next!;
    }

    private static IEnumerable<int> AsEnumerable(ListNode? node)
    {
        if (node is null)
            yield break;

        while (node?.val is int val)
        {
            yield return val;
            node = node?.next;
        }
    }
}
