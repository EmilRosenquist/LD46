using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipe
{
    public bool unlocked = false;
    public string recipeTitle = "";
    public int itemId = 0;
    public Dictionary<int, int> requiredMaterials;
    public CraftingRecipe(string recipeTitle, int itemId, Dictionary<int,int> requiredMaterials, bool unlocked = false) 
    {
        this.recipeTitle = recipeTitle;
        this.unlocked = unlocked;
        this.itemId = itemId;
        this.requiredMaterials = requiredMaterials;
    }
}

public class CraftingRecipeDatabase
{
    public static List<CraftingRecipe> craftingRecipes = new List<CraftingRecipe>();
    public CraftingRecipeDatabase()
    {
        craftingRecipes = new List<CraftingRecipe>()
        {
            new CraftingRecipe("Fence", 4, new Dictionary<int, int>{{2,5}}, true)
        };
    }
    public static CraftingRecipe GetRecipe(string title)
    {
        return craftingRecipes.Find(recipe => recipe.recipeTitle == title);
    }
    public static List<CraftingRecipe> GetCraftingRecipes()
    {
        List<CraftingRecipe> unlocked = new List<CraftingRecipe>();
        foreach(var recipe in craftingRecipes)
        {
            if(recipe.unlocked)
            {
                unlocked.Add(recipe);
            }
        }
        return unlocked;
    }
    public static List<CraftingRecipe> GetPossibleRecipes(Inventory inventory)
    {
        List<CraftingRecipe> possible = new List<CraftingRecipe>();
        var items = inventory.GetItems();
        foreach (var recipe in craftingRecipes)
        {
            if (recipe.unlocked)
            {
                int possibles = 0;
                foreach (var material in recipe.requiredMaterials)
                {
                    if(items.ContainsKey(material.Key))
                    {
                        if(items[material.Key] >= material.Value)
                        {
                            possibles++;
                        }
                    }
                }
                if(possibles == recipe.requiredMaterials.Count)
                {
                    possible.Add(recipe);
                }
            }
        }
        return possible;
    }
}

public class CraftingHut : MonoBehaviour, IMouseInteractable
{
    public int craftRange = 10;
    CraftingRecipeDatabase mCraftingRecipeDatabase;

    public void Awake()
    {
        mCraftingRecipeDatabase = new CraftingRecipeDatabase();
    }

    public string GetText()
    {
        return "Use this hut to craft stuff.";
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if(Vector3.Distance(transform.position, position) < craftRange)
        {
            FindObjectOfType<CraftingMenuHandeler>().ToggleCraftingMenu();
            Debug.Log("Start craft away!");
        }
        else
        {
            Debug.Log("To far away to craft");
        }
    }
}
