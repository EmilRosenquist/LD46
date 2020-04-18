using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CraftingMenuHandeler : MonoBehaviour, IToolTipable, ICraftClick
{
    [SerializeField] private GameObject slot;
    [SerializeField] private Inventory inventory;
    [SerializeField] private GameObject recipesDrawer;
    Dictionary<CraftingRecipe, GameObject> recipeButtonPair = new Dictionary<CraftingRecipe, GameObject>();
    Dictionary<GameObject, CraftingRecipe> buttonRecipePair = new Dictionary<GameObject, CraftingRecipe>();
    private bool currentlyOpen;
    [SerializeField] private GameObject dude;
    [SerializeField] private GameObject craftingHut;

    private void Start()
    {
        currentlyOpen = recipesDrawer.activeInHierarchy;
        if (currentlyOpen) ToggleCraftingMenu();

        if (!dude) dude = FindObjectOfType<DudeMovement>().gameObject;
        if (craftingHut) craftingHut = FindObjectOfType<CraftingHut>().gameObject;
    }

    private void Update()
    {
        if (currentlyOpen)
        {
            if(Vector3.Distance(dude.transform.position, craftingHut.transform.position) > 10)
            {
                ToggleCraftingMenu();
            }
            else
            {
                UpdateCraftingMenu();
            }
        }
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
                r.GetComponent<MenuSlot>().SetTooltipSource(this);
                r.GetComponent<MenuSlot>().SetItemCraftable(this);
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
            string toolTip = "Craft " + ItemDatabase.GetItem(buttonRecipePair[slot].itemId).mTitle + " ";
            foreach(var matPair in buttonRecipePair[slot].requiredMaterials)
            {
                mats.Add(matPair.Value + " amount of " + ItemDatabase.GetItem(matPair.Key).mTitle);
            }
            for(int i = 0; i < mats.Count; i++)
            {
                toolTip += mats[i];
                if (i != mats.Count - 1) toolTip += " and ";
            }
            //tooltipTMP.text = toolTip;
            ToolTipHandler.instance.SetText(toolTip);
        }
    }

    public void HideToolTip(GameObject slot)
    {
        //tooltipTMP.text = "";
    }

    public void CraftItem(GameObject slot)
    {
        if (buttonRecipePair.ContainsKey(slot))
        {
            List<CraftingRecipe> availableRecipes = CraftingRecipeDatabase.GetPossibleRecipes(inventory);

            if (availableRecipes.Contains(buttonRecipePair[slot]))
            {
                Debug.Log("Crafting " + ItemDatabase.GetItem(buttonRecipePair[slot].itemId).mTitle);
                foreach (var matPair in buttonRecipePair[slot].requiredMaterials)
                {
                    
                    inventory.RemoveItemid(matPair.Key, matPair.Value);
                }
                inventory.AddItemId(buttonRecipePair[slot].itemId, 1);
            }
            else
            {
                Debug.Log("Not enough Mats");
            }
        }


    }
}
