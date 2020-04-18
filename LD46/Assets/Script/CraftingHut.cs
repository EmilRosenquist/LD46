using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingHut : MonoBehaviour, IMouseInteractable
{
    public int craftRange = 10;
    public string GetText()
    {
        return "Use this hut to craft stuff.";
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if(Vector3.Distance(transform.position, position) < craftRange)
        {
            Debug.Log("Start craft away!");
        }
        else
        {
            Debug.Log("To far away to craft");
        }
    }
}
