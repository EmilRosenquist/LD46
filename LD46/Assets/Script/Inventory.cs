using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> mItems = new List<Item>();
    void Start()
    {
        mItems.Add(ItemDatabase.GetItem(1));
    }

    void Update()
    {
    }
}
