public class RandomizedSet
{
    private Dictionary<int, int> map = [];
    private List<int> nums = [];
    private Random rand = new();

    public bool Insert(int item)
    {
        if (!map.TryAdd(item, nums.Count))
            return false;

        nums.Add(item);
        return true;
    }

    public bool Remove(int item)
    {
        if (map.TryGetValue(item, out int idx))
        {
            nums[idx] = nums[^1];
            map[nums[idx]] = idx;

            nums.RemoveAt(nums.Count-1);
            map.Remove(item);

            return true;
        }

        return false;
    }

    public int GetRandom()
        => nums[rand.Next(nums.Count)];
}