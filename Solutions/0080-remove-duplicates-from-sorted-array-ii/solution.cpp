class Solution {
public:
    int removeDuplicates(vector<int>& nums) 
    {
        int writeIdx = 0;
        bool seenTwice = false;

        for (size_t i = 1; i < nums.size(); i++)
        {
            if (nums[i] == nums[writeIdx] && !seenTwice)
            {
                nums[++writeIdx] = nums[i];
                seenTwice = true;
            }

            else if (nums[i] != nums[writeIdx])
            {
                nums[++writeIdx] = nums[i];
                seenTwice = false;
            }
        }

        return ++writeIdx;
    }
};
