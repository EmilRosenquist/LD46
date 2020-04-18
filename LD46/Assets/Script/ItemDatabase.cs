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
            new Stone(1, "Stone"),
            new Item(2, "Wood")
        };
    }
}
