public class Solution
{
    public bool IsPalindrome(ListNode? head)
    {
        if (head is null) return true;
        ListNode? fast = head, middle = head;
        ListNode? prevMiddle = null;

        while (fast?.next is not null)
        {
            // moving the fast ptr BEFORE ANY REVERSAL SHENANIGANS
            fast = fast.next?.next;

            // ======================= //

            var temp = middle!.next;
            middle.next = prevMiddle;

            prevMiddle = middle;
            middle = temp;
        }

        if (fast is not null) // if the count is odd
            middle = middle!.next; // move mid +1 bc the middle element in odd list doesnt matter in palindromes

        // if [middle : start] == [middle : end] then its a palindrome
        var goingLeft = prevMiddle;
        var goingRight = middle;

        while (goingLeft is not null && goingRight is not null)
        {
            if (goingLeft.val != goingRight.val)
                return false;

            goingLeft = goingLeft.next;
            goingRight = goingRight.next;
        }

        return true;
    }
}