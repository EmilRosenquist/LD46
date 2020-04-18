using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteracter : MonoBehaviour
{
    private Camera mCam;
    void Start()
    {
        mCam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseInteractable = GetMouseInteractable();
            if (mouseInteractable != null)
            {
                mouseInteractable.OnPress();
            }
        }
        else if (MouseHasMoved())
        {
            var mouseInteractable = GetMouseInteractable();
            if (mouseInteractable != null)
            {
                Debug.Log(mouseInteractable.GetText());
            }
        }
    }
    IMouseInteractable GetMouseInteractable()
    {
        var ray = mCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("MouseInteraction"))
            {
                return hit.transform.GetComponent<IMouseInteractable>();
            }
        }
        return null;
    }
    bool MouseHasMoved()
    {
        return (Input.GetAxis("Mouse X") != 0 && Input.GetAxis("Mouse Y") != 0);
    }
}
