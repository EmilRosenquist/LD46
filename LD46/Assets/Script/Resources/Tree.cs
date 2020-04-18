using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, IMouseInteractable
{
    public int chopRange = 2;
    public int woodItemId = 2;

    public string GetText()
    {
        return "Click here to chop wood";
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if (Vector3.Distance(position, transform.position) < chopRange)
        {
            //Todo Go into animation state.
            inventory.AddItemId(woodItemId, 1);
            Debug.Log("chopped wood");
        }
        else
        {
            Debug.Log("To far away");
        }
    }
}