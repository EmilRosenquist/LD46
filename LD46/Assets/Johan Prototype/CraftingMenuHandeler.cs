using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingMenuHandeler : MonoBehaviour, IToolTipable
{
    [SerializeField] private GameObject slot;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject recipesDrawer;
    [SerializeField] private TextMeshProUGUI tooltipTMP;
    Dictionary<CraftingRecipe, GameObject> recipeButtonPair = new Dictionary<CraftingRecipe, GameObject>();
    Dictionary<GameObject, CraftingRecipe> buttonRecipePair = new Dictionary<GameObject, CraftingRecipe>();
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
        for (int i = 0; i < unlockedRecipes.Count; i++)
        {
            if (!recipeButtonPair.ContainsKey(unlockedRecipes[i]))
            {
                GameObject r = Instantiate(slot);
                r.transform.SetParent(recipesDrawer.transform);
                r.transform.localScale = new Vector3(1f, 1f, 1f);
                Item item = ItemDatabase.GetItem(unlockedRecipes[i].itemId);
                r.transform.GetChild(0).GetComponent<Image>().sprite = item.mIconSprite;
                r.transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 0f, 0f, 0.2f);
                recipeButtonPair.Add(unlockedRecipes[i], r);
                buttonRecipePair.Add(r, unlockedRecipes[i]);
                r.GetComponent<ToolTipHandler>().SetTooltipSource(this);
            }
        }
        for (int i = 0; i < availableRecipes.Count; i++)
        {
            if (recipeButtonPair.ContainsKey(availableRecipes[i]))
            {
                recipeButtonPair[availableRecipes[i]].transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    public void ToggleCraftingMenu()
    {
        UpdateCraftingMenu();
        recipesDrawer.SetActive(!currentlyOpen);
        currentlyOpen = recipesDrawer.activeInHierarchy;
    }

    public void ShowToolTip(GameObject slot)
    {
        if (buttonRecipePair.ContainsKey(slot))
        {
            List<string> mats = new List<string>();
            foreach(var matPair in buttonRecipePair[slot].requiredMaterials)
            {
                print(matPair);
                mats.Add(matPair.Value + " amount of " + ItemDatabase.GetItem(matPair.Key).mTitle);
            }
            string toolTip = "Craft " + ItemDatabase.GetItem(buttonRecipePair[slot].itemId).mTitle + " ";
            
            for(int i = 0; i < mats.Count; i++)
            {
                toolTip += mats[i];
                if (i != mats.Count - 1) toolTip += " and ";
            }
            tooltipTMP.text = toolTip;
        }
    }

    public void HideToolTip(GameObject slot)
    {
        tooltipTMP.text = "";
    }
}
