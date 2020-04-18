using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public int itemId = 0;
    private Item item;
    void Awake()
    {
        item = ItemDatabase.GetItem(itemId);
    }

    void Update()
    {
        
    }
}
