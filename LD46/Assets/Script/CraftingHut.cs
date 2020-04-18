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
    CraftingRecipeDatabase()
    {
        craftingRecipes = new List<CraftingRecipe>()
        {
            new CraftingRecipe("Fence", 4, new Dictionary<int, int>{{2,5}})
        };
    }
    public static CraftingRecipe GetRecipe(string title)
    {
        return craftingRecipes.Find(recipe => recipe.recipeTitle == title);
    }
}

public class CraftingHut : MonoBehaviour, IMouseInteractable
{
    public int craftRange = 10;
    public string GetText()
    {
        return "Use this hut to craft stuff.";
    }

    public void OnPress(Vector3 position, Inventory inventory)
    {
        if(Vector3.Distance(transform.position, position) < craftRange)
        {
            Debug.Log("Start craft away!");
        }
        else
        {
            Debug.Log("To far away to craft");
        }
    }
}
