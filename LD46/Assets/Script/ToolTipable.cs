using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IToolTipable
{
    void ShowToolTip(GameObject slot);
    void HideToolTip(GameObject slot);
}

public interface ICraftClick
{
    void CraftItem(GameObject slot);
}

public interface IEnemy
{
    void SetRegion(GameObject region);
}