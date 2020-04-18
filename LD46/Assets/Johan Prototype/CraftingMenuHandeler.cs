using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingMenuHandeler : MonoBehaviour
{
    [SerializeField] private GameObject slot;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject recipesDrawer;
    List<CraftingRecipe> drawn = new List<CraftingRecipe>();
    Dictionary<int, GameObject> idButtonPair = new Dictionary<int, GameObject>();
    private bool currentlyOpen;

    private void Start()
    {
        currentlyOpen = recipesDrawer.activeInHierarchy;
        if (currentlyOpen) ToggleCraftingMenu();
    }

    private void Update()
    {
        if (currentlyOpen) UpdateCraftingMenu();
        if (currentlyOpen && Input.GetKeyDown(KeyCode.Escape)) ToggleCraftingMenu();
    }

    void UpdateCraftingMenu()
    {
        List<CraftingRecipe> unlockedRecipes = CraftingRecipeDatabase.GetCraftingRecipes();
        List<CraftingRecipe> availableRecipes = CraftingRecipeDatabase.GetPossibleRecipes(inventory);
        print(unlockedRecipes.Count);
        for (int i = 0; i < unlockedRecipes.Count; i++)
        {
            if (!idButtonPair.ContainsKey(unlockedRecipes[i].itemId))
            {
                GameObject r = Instantiate(slot);
                r.transform.SetParent(recipesDrawer.transform);
                r.transform.localScale = new Vector3(1f, 1f, 1f);
                Item item = ItemDatabase.GetItem(unlockedRecipes[i].itemId);
                r.transform.GetChild(0).GetComponent<Image>().sprite = item.mIconSprite;
                r.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.2f);
                r.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "KUK";
                idButtonPair.Add(item.mId, r);
            }
        }
        for (int i = 0; i < availableRecipes.Count; i++)
        {
            if (idButtonPair.ContainsKey(availableRecipes[i].itemId))
            {
                idButtonPair[availableRecipes[i].itemId].transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
                idButtonPair[availableRecipes[i].itemId].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "OBROR";
            }
        }
    }

    public void ToggleCraftingMenu()
    {
        UpdateCraftingMenu();
        recipesDrawer.SetActive(!currentlyOpen);
        currentlyOpen = recipesDrawer.activeInHierarchy;
    }
}
