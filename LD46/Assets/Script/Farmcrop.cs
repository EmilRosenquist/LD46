using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmcrop : MonoBehaviour, IMouseInteractable
{
    public int cropItemId = 3;
    public float growRate = 1 / 100;
    public float currentGrowth = 0;
    void FixedUpdate()
    {
        if (currentGrowth < 1)
        {
            currentGrowth += growRate * Time.fixedDeltaTime;
            currentGrowth = Mathf.Clamp(currentGrowth, 0, 1);
        }
    }
    public string GetText()
    {
        return "Crop is " + (currentGrowth / 1.0) * 100 + "% done.";
    }

    public void OnPress(Inventory inventory)
    {
        if (currentGrowth >= 1)
        {
            inventory.AddItemId(cropItemId, 1);
            Destroy(transform.gameObject);
        }
        else
        {
            Debug.Log("Crop not done");
        }
    }
}
