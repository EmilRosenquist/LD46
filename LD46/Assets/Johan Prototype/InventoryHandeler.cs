using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandeler : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject FullBasketInventory;
    private bool currentlyOpen;


    // Start is called before the first frame update
    void Start()
    {
        currentlyOpen = FullBasketInventory.activeInHierarchy;
        if (currentlyOpen) ToggleInventoryWindow();
    }

    // Update is called once per frame
    void Update()
    {
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
        int amountOfItems = items.Count;
        print(amountOfItems);
    }
}
