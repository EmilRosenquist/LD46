using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMouseInteractable : MonoBehaviour, IMouseInteractable
{
    public string GetText()
    {
        return "Hovering over : " + transform.name;
    }

    public void OnPress(Inventory inventory)
    {
        var itemObject = transform.GetComponent<ItemObject>();
        if (itemObject != null)
        {
            inventory.AddItemId(itemObject.itemId, 1);
        }
        Destroy(transform.gameObject);
    }
}
