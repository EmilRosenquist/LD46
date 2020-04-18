using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceScript : MonoBehaviour, IMouseInteractable
{
    [SerializeField] private bool broken;
    [SerializeField] private int fenceID = 4;
    [SerializeField] private float repairRange;
    BoxCollider bc;
    MeshRenderer brokenMesh;
    MeshRenderer wholeMesh;

    public void Start()
    {
        bc = GetComponent<BoxCollider>();
        wholeMesh = transform.GetChild(0).GetComponent<MeshRenderer>();
        brokenMesh = transform.GetChild(1).GetComponent<MeshRenderer>();
        wholeMesh.enabled = !broken;
        brokenMesh.enabled = broken;
        bc.isTrigger = broken;

    }

    public void Break()
    {
        broken = true;
        wholeMesh.enabled = !broken;
        brokenMesh.enabled = broken;
        bc.isTrigger = broken;
    }

    public void Repair()
    {
        broken = false;
        wholeMesh.enabled = !broken;
        brokenMesh.enabled = broken;
        bc.isTrigger = broken;
    }

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
                    Repair();
                }
                else
                {
                    ToolTipHandler.instance.SetText("Cant Repair fence, Craft fence");
                }
            }
        }
    }
}
