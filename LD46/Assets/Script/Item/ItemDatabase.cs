using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{

    public static List<Item> mItems = new List<Item>();
    void Awake()
    {
        BuildDatabase();
    }
    public static Item GetItem(int id)
    {
        return mItems.Find(item => item.mId == id);
    }
    public static Item GetItem(string title)
    {
        return mItems.Find(item => item.mTitle == title);
    }
    void BuildDatabase()
    {
        mItems = new List<Item>()
        {
            new Item(1, "Stone", "Stone"),
            new Item(2, "Wood"),
            new Item(3, "Crop"),
            new Item(4, "Fence", "Fence"),
            new Item(5, "Copper"),
            new Item(6, "Iron")
        };
    }
}
