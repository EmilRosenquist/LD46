using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int mId;
    public string mTitle;
    public Sprite mIconSprite;
    public Item(int id, string title)
    {
        mId = id;
        mTitle = title;
        mIconSprite = Resources.Load<Sprite>("Sprites/Items/" + title);
    }
    public virtual void Use()
    {

    }
}
