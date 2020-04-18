using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour, IMouseInteractable
{
    [SerializeField] private GameObject fencePrefab;
    [SerializeField] private GameObject brokenFencePrefab;
    [SerializeField] private bool broken;
    [SerializeField] private int fenceID = 4;
    [SerializeField] private float repairRange;
    
    public string GetText()
    {
        return "Hovering over : " + transform.name;
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        
        if (broken)
        {
            if (Vector3.Distance(position, transform.position) < repairRange)
            {
                Dictionary<int, int> items = inventory.GetItems();
                if (items.ContainsKey(4))
                {
                    ToolTipHandler.instance.SetText("Repaired Fence");
                }
                else
                {
                    ToolTipHandler.instance.SetText("Cant Repair fence, Craft fence");
                }
            }
        }
    }
}
