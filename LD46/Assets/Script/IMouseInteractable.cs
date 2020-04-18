﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInteractable
{
    void OnPress();
    void OnPress(Inventory inventory);
    string GetText();
}
