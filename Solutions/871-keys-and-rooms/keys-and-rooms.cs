using System.Collections;

public class Solution
{
    public bool CanVisitAllRooms(IList<IList<int>> roomKeys)
    {
        BitArray keysObtained = new(length: roomKeys.Count);
        
        void dfs(int roomNum)
        {
            var keys = roomKeys[roomNum];

            foreach(int key in keys)
            {
                if (keysObtained[key])
                    continue;

                keysObtained[key] = true;
                dfs(key);
            }
        }

        keysObtained[0] = true;
        dfs(0);

        return keysObtained.HasAllSet();
    }
}