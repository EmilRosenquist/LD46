﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryHandeler : MonoBehaviour, IToolTipable
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject FullBasketInventory;
    private bool currentlyOpen;
    private List<GameObject> backPackSlots = new List<GameObject>();
    Dictionary<GameObject, Item> buttonItemPair = new Dictionary<GameObject, Item>();


    // Start is called before the first frame update
    void Start()
    {
        currentlyOpen = FullBasketInventory.activeInHierarchy;
        for (int i = 0; i < FullBasketInventory.transform.childCount; i++)
        {
            backPackSlots.Add(FullBasketInventory.transform.GetChild(i).gameObject);
            backPackSlots[i].GetComponent<MenuSlot>().SetTooltipSource(this);
        }
        if (currentlyOpen) ToggleInventoryWindow();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            ToggleInventoryWindow();
        }
        if (currentlyOpen)
        {
            UpdateInventory();
        }
    }

    public void ToggleInventoryWindow()
    {
        FullBasketInventory.SetActive(!currentlyOpen);
        currentlyOpen = FullBasketInventory.activeInHierarchy;
    }

    void UpdateInventory()
    {
        Dictionary<int, int> items = inventory.GetItems();
        for (int j = 0; j < backPackSlots.Count; j++)
        {
            backPackSlots[j].transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0f);
            backPackSlots[j].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
        }

        int i = 0;
        buttonItemPair.Clear();
        foreach(int key in items.Keys)
        {
            Item item = ItemDatabase.GetItem(key);
            if(items[key] > 0)
            {
                buttonItemPair.Add(backPackSlots[i], item);
                backPackSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = item.mIconSprite;
                backPackSlots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                backPackSlots[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = items[key].ToString();
                i++;
            }
        }
    }

    public void ShowToolTip(GameObject slot)
    {
        if(buttonItemPair.ContainsKey(slot))
            //tooltipTMP.text = buttonItemPair[slot].mTitle;
            ToolTipHandler.instance.SetText(buttonItemPair[slot].mTitle);
    }

    public void HideToolTip(GameObject slot)
    {
        //tooltipTMP.text = "";
    }
}
