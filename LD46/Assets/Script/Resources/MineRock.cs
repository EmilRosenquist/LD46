using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DropRate
{
    public int mineralId;
    public float dropChance;
}

public class MineRock : MonoBehaviour, IMouseInteractable
{
    public int mineRange = 2;
    public List<DropRate> droprates;

    public string GetText()
    {
        return "Click here to mine stone";
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if (Vector3.Distance(position, transform.position) < mineRange)
        {
            //Todo Go into animation state.
            var random = Random.Range(0f, 1f);
            foreach(var rate in droprates)
            {
                random -= rate.dropChance;
                if(random <= 0)
                {
                    inventory.AddItemId(rate.mineralId, 1);
                    break;
                }
            }

            Debug.Log("Mined stone");
        }
        else
        {
            Debug.Log("To far away");
        }
    }
}
