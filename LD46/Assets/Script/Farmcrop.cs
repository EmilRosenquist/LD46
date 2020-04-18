using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmcrop : MonoBehaviour, IMouseInteractable
{
    public int farmRange = 2;
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

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if(Vector3.Distance(position, transform.position) < farmRange)
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
        else
        {
            Debug.Log("To far away");
        }
    }
}
