using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineRock : MonoBehaviour, IMouseInteractable
{
    public int mineRange = 2;
    public int stoneItemId = 1;

    public string GetText()
    {
        return "Click here to mine stone";
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if (Vector3.Distance(position, transform.position) < mineRange)
        {
            //Todo Go into animation state.
            inventory.AddItemId(stoneItemId, 1);
            Debug.Log("Mined stone");
        }
        else
        {
            Debug.Log("To far away");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
