using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInteractable
{
    void OnPress(Vector3 position, Inventory inventory);
    string GetText();
}
