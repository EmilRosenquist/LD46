using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMouseInteractable : MonoBehaviour, IMouseInteractable
{
    public string GetText()
    {
        return "Hovering over : " + transform.name;
    }

    public void OnPress()
    {
        Debug.Log("Pressing on :" + transform.name);
    }
}
