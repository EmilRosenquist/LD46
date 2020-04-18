using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Item
{
    public Stone(int id, string title) : base(id, title)
    {
    }
    public override void Use()
    {
        Debug.Log("Using stone");
    }
}
