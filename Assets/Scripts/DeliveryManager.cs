using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler<OnRecipeEventArgs> OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;
    public event EventHandler<OnRecipeEventArgs> OnRecipeAdded;

    public class OnRecipeEventArgs : EventArgs
    {
        public RecipeSO recipeSO;
    }

    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecipeListSO recipeListSO;
    
    private List<RecipeSO> waitingRecipeSOList;

    private float spawnRecipeTimer;
    [SerializeField] private float spawnRecipeTimerMax = 10f;
    private int waitingRecipesMax = 3;


    private void Awake()
    {
        Instance = this;
        waitingRecipeSOList = new List<RecipeSO>();
    }
    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;
            if(waitingRecipeSOList.Count < waitingRecipesMax ) 
            { 
            RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO.recipeName);
            waitingRecipeSOList.Add(waitingRecipeSO);
                OnRecipeAdded?.Invoke(this, new OnRecipeEventArgs
                {
                    recipeSO = waitingRecipeSO,
                });
            }
        }
    }


    public void DeliverRecipe(PlateBrothKitchenObject plateBrothKitchenObject)
    {
        for(int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];
            if(waitingRecipeSO.kitchenObjectSOList.Count == plateBrothKitchenObject.GetKitchenObjectSOList().Count)
            {
                bool plateContentsMatchesRecipe = true;
                foreach(KitchenObject_SO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    bool ingredientFound = false;
                    foreach(KitchenObject_SO plateKitchenObjectSO in plateBrothKitchenObject.GetKitchenObjectSOList())
                    {
                        if(plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            ingredientFound = true;
                            break;
                        }
                    }
                    if(!ingredientFound)
                    {
                        plateContentsMatchesRecipe = false;
                    }
                }
                if(plateContentsMatchesRecipe)
                {
                    //poprawny przepis
                    Debug.Log("Oddano przepis!");
                    waitingRecipeSOList.RemoveAt(i);
                    OnRecipeSuccess?.Invoke(this, new OnRecipeEventArgs
                    {
                        recipeSO = waitingRecipeSO
                    });
                    return;
                }
            }
        }
        //Nie znaleziono przepisu
        //Gracz nie przekazal poprawnego przepisu
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        Debug.Log("Gracz nie przekazal poprawnego przepisu");
    }
}
