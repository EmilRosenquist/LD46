using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int selectedItem = 1;
    private Dictionary<int, int> mItems = new Dictionary<int, int>();
    public Dictionary<int, int> GetItems()
    {
        return mItems;
    }
    public void AddItemId(int id, int amount)
    {
        if(mItems.ContainsKey(id))
        {
            mItems[id] += amount;
        }
        else
        {
            mItems.Add(id, amount);
        }
    }
    
    public void RemoveItemid(int id, int amount)
    {
        if(mItems.ContainsKey(id))
        {
            mItems[id] -= amount;
            if (mItems[id] < 0)
            {
                Debug.LogError("Not enough amount of item to remove");
            }
        }
        else
        {
            Debug.LogError("Item does not exists in invetory");
        }
    }
    public int GetSelectedItem()
    {
        return selectedItem;
    }
}
