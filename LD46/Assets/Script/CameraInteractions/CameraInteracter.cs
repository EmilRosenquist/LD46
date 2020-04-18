using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteracter : MonoBehaviour
{
    public Transform playerTransform;
    public Inventory playerInventory;
    private Camera mCam;
    void Start()
    {
        mCam = GetComponent<Camera>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            if(GetHit(out hit))
            {
                var mouseInteractable = GetMouseInteractable(hit);
                if (mouseInteractable != null)
                {
                    mouseInteractable.OnPress(playerTransform.position, playerInventory);
                }
            }
        }
        else if(Input.GetMouseButtonUp(0) && playerInventory.GetSelectedItem() > 0)
        {
            if (GetHit(out hit))
            {
                Item item = ItemDatabase.GetItem(playerInventory.GetSelectedItem());
                if(item.mPrefab != null)
                {
                    GameObject instance = Instantiate(item.mPrefab, hit.point, Quaternion.identity);
                }
            }
        }
        else if (MouseHasMoved())
        {
            if (GetHit(out hit))
            {
                if(playerInventory.GetSelectedItem() > 0)
                {
                }
                else
                {
                    var mouseInteractable = GetMouseInteractable(hit);
                    if (mouseInteractable != null)
                    {
                        Debug.Log(mouseInteractable.GetText());
                    }
                }
            }
        }
    }
    bool GetHit(out RaycastHit hit)
    {
        var ray = mCam.ScreenPointToRay(Input.mousePosition);
        return Physics.Raycast(ray, out hit);
    }
    IMouseInteractable GetMouseInteractable(RaycastHit hit)
    {
        if (hit.transform.gameObject.layer == LayerMask.NameToLayer("MouseInteraction"))
        {
            return hit.transform.GetComponent<IMouseInteractable>();
        }
        return null;
    }
    bool MouseHasMoved()
    {
        return (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0);
    }
}
