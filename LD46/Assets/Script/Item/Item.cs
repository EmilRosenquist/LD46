using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int mId;
    public string mTitle;
    public Sprite mIconSprite;
    public GameObject mPrefab;
    public Item(int id, string title)
    {
        mId = id;
        mTitle = title;
        mIconSprite = Resources.Load<Sprite>("Sprites/Items/" + title);
        mPrefab = null;
    }
    public Item(int id, string title, string prefab)
    {
        mId = id;
        mTitle = title;
        mIconSprite = Resources.Load<Sprite>("Sprites/Items/" + title);
        mPrefab = Resources.Load<GameObject>("Prefabs/" + prefab);
    }
}
